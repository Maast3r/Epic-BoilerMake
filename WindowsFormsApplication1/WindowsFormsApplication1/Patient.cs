using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace WindowsFormsApplication1
{
    class Patient
    {
        private string name;
        private DateTime birthDate;
        private string streetAddress;
        private List<string> phoneNumbers;

        public Patient(string name, DateTime birthDate, string streetAddress, List<string> phoneNumbers)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.streetAddress = streetAddress;
            this.phoneNumbers = phoneNumbers;
        }

        public static Patient findPatient(string firstName, string lastName, DateTime birthDate, string streetAddress, string gender, string phoneNumber)
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
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            // TODO convert to support multiple results, ask epic
            json = json.Bundle.entry.resource.Patient;
            //Console.WriteLine(json);
            return createPatientFromJson(json);
        }

        private static Patient createPatientFromJson(dynamic json)
        {
            string name = json.name.given["@value"] + " " + json.name.family["@value"];
            DateTime birthDate = (DateTime) json.birthDate["@value"];
            string streetAddress = json.address.line["@value"];
            List<string> phoneNumbers = new List<string>();
            foreach (dynamic phoneJson in json.telecom)
            {
                phoneNumbers.Add((string) phoneJson.value["@value"]);
            }
            return new Patient(name, birthDate, streetAddress, phoneNumbers);
        }

        private static List<Tuple<string, string>> generateParamsList(string firstName, string lastName, DateTime birthDate, string streetAddress, string gender, string phoneNumber)
        {
            List<Tuple<string, string>> stringParams = new List<Tuple<string, string>>();
            stringParams.Add(tuple("given", firstName));
            stringParams.Add(tuple("family", lastName));

            //stringParams.Add(tuple("birthdate", birthDate.ToShortDateString()));
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
    }
}
