using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace WindowsFormsApplication1
{
    class Patient
    {
        private string id;
        private string name;
        private DateTime birthDate;
        private string streetAddress;
        private List<string> phoneNumbers;
        private List<Perscription> perscriptions;

        public Patient(string id, string name, DateTime birthDate, string streetAddress, List<string> phoneNumbers)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.streetAddress = streetAddress;
            this.phoneNumbers = phoneNumbers;
            this.perscriptions = Perscription.findPerscriptions(this.id);
        }

        public string getId()
        {
            return this.id;
        }

        public static Patient findPatient(string firstName, string lastName, string birthDate, string streetAddress, string gender, string phoneNumber)
        {
            List<Tuple<string, string>> stringParams = generateParamsList(firstName, lastName, birthDate, streetAddress, gender, phoneNumber);

            var client = new RestClient("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/");
            client.ClearHandlers();
            client.AddHandler("application/xml", new XmlDeserializer());
            client.AddHandler("text/xml", new XmlDeserializer());

            var request = new RestRequest("Patient");
            request.RequestFormat = DataFormat.Xml;
            foreach (Tuple<string, string> param in stringParams)
            {
                request.AddParameter(param.Item1, param.Item2);
            }

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            dynamic json = (dynamic) JsonConvert.DeserializeObject(jsonString);

            string id = json.Bundle.entry.link.url["@value"];
            id = id.Replace("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/Patient/", "");
            json = json.Bundle.entry.resource.Patient;
            //Console.WriteLine(json);
            return createPatientFromJson(json, id);
        }
        
        private static Patient createPatientFromJson(dynamic json, string id)
        {
            string name = json.name.given["@value"] + " " + json.name.family["@value"];
            DateTime birthDate = (DateTime) json.birthDate["@value"];
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
            return new Patient(id, name, birthDate, streetAddress, phoneNumbers);
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
            return "id: " + this.id + "\nname:  " + this.name + "\nbirthDate: " + this.birthDate.ToShortDateString() + "\nstreetAddress: " + this.streetAddress + "\nphoneNumbers: " + string.Join<string>(", ", this.phoneNumbers);
        }
    }
}
