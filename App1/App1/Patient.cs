﻿using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace App1
{
    class Patient
    {
        private string id;
        private string name;
        private DateTime birthDate;
        private string streetAddress;
        private List<string> phoneNumbers;
        private List<Perscription> perscriptions;

        public Patient(string id, string name, DateTime birthDate, string streetAddress, List<string> phoneNumbers, List<Perscription> perscriptions)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.streetAddress = streetAddress;
            this.phoneNumbers = phoneNumbers;
            this.perscriptions = perscriptions != null ? perscriptions : Perscription.findPerscriptions(this.id);
        }

        public string getId()
        {
            return this.id;
        }

        public List<Perscription> getPerscriptions()
        {
            return this.perscriptions;
        }

        private static async System.Threading.Tasks.Task<string> doRequest(HttpClient client, Uri uri)
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;
            return await response.Content.ReadAsStringAsync();
        }


        public static Patient findPatient(string firstName, string lastName, string birthDate, string streetAddress, string gender, string phoneNumber)
        {
            // donesn't work
            List<Tuple<string, string>> stringParams = generateParamsList(firstName, lastName, birthDate, streetAddress, gender, phoneNumber);
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));

            //var client = new RestClient();

            //client.ClearHandlers();
            //client.AddHandler("application/xml", new XmlDeserializer());
            //client.AddHandler("text/xml", new XmlDeserializer());

            UriBuilder uriBuilder = new UriBuilder();
            // https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/
            uriBuilder.Scheme = "https";
            uriBuilder.Host = "open-ic.epic.com";
            uriBuilder.Path = "FHIR/api/FHIR/DSTU2/Patient";

            //var request = new RestRequest("Patient");
            //request.RequestFormat = DataFormat.Xml;
            string queryString = "";
            foreach (Tuple<string, string> param in stringParams)
            {
                queryString = queryString + param.Item1 + "=" + param.Item2 + "&";
                //request.AddParameter(param.Item1, param.Item2);
            }
            uriBuilder.Query = queryString.Substring(0, queryString.Length - 1);
            Uri uri = uriBuilder.Uri;
            string content = doRequest(client, uri).Result;

            //string content = await response.Content.ReadAsStringAsync();
            //Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Test: " + await response.Content.ReadAsStringAsync());

            //m.ShowAsync();
            int five = 5;
            //IRestResponse response = client.Execute(request);
            //var content = response.Content;

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(content);

            //string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            //dynamic json = (dynamic)JsonConvert.DeserializeObject(jsonString);
            // if there are multiple users, pick one functionality goes here
            //XmlToJSON(doc)

            //dynamic json = JsonConvert.DeserializeObject<dynamic>(content);
            

            //JArray entry = json["Bundle"]["entry"];
            //dynamic blah = entry.First["link"]["url"];
            //string id = entry.link.url["@value"];
            //string id = "";

            //id = id.Replace("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/Patient/", "");
            //json = json.Bundle.entry.resource.Patient;
            //return createPatientFromJson(json, id);
            return null;
        }

        private static Patient createPatientFromJson(dynamic json, string id)
        {
            string name = json.name.given["@value"] + " " + json.name.family["@value"];
            DateTime birthDate = (DateTime)json.birthDate["@value"];
            string streetAddress = json.address.line["@value"];
            List<string> phoneNumbers = new List<string>();
            if (json.telecom != null && json.telecom.Type == null)
            {
                if (json.telecom.system["@value"] == "phone")
                {
                    phoneNumbers.Add((string)json.telecom.value["@value"]);
                }
            }
            else
            {
                foreach (dynamic phoneJson in json.telecom)
                {
                    if (phoneJson.system["@value"] == "phone")
                    {
                        phoneNumbers.Add((string)phoneJson.value["@value"]);
                    }
                }
            }
            return new Patient(id, name, birthDate, streetAddress, phoneNumbers, null);
        }

        private static List<Tuple<string, string>> generateParamsList(string firstName, string lastName, string birthDate, string streetAddress, string gender, string phoneNumber)
        {
            List<Tuple<string, string>> stringParams = new List<Tuple<string, string>>();
            stringParams.Add(tuple("given", firstName));
            stringParams.Add(tuple("family", lastName));

            if (birthDate != "")
            {
                stringParams.Add(tuple("birthdate", birthDate));
            }
            if (streetAddress != "")
            {
                stringParams.Add(tuple("address", streetAddress));
            }
            if (gender != "")
            {
                stringParams.Add(tuple("gender", gender));
            }
            if (phoneNumber != "" && phoneNumber.Length == 10)
            {
                stringParams.Add(tuple("", phoneNumber));
            }
            return stringParams;
        }

        private static Tuple<string, string> tuple(string paramName, string paramValue)
        {
            return new Tuple<string, string>(paramName, paramValue);
        }

        public string toString()
        {
            return "id: " + this.id + "\nname:  " + this.name + "\nbirthDate: " +
                this.birthDate.Date + "\nstreetAddress: " + this.streetAddress +
                "\nphoneNumbers: " + string.Join<string>(", ", this.phoneNumbers) +
                "\nNumber of perscriptions: " + this.perscriptions.Count;
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Patient fromJson(string json)
        {
            return JsonConvert.DeserializeObject<Patient>(json);

        }
    }
}
