using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using RestSharp;

namespace WindowsFormsApplication1
{
    class Patient
    {
        private string name;
        private DateTime birthDate;
        private string streetAddress;
        private string gender;
        private int[] phoneNumbers;

        public Patient(string name, DateTime birthDate, string streetAddress, string gender, int[] phoneNumbers)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.streetAddress = streetAddress;
            this.gender = gender;
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
            json = json.Patient;

            // create patient

        }

        private static List<Tuple<string, string>> generateParamsList(string firstName, string lastName, DateTime birthDate, string streetAddress, string gender, string phoneNumber)
        {
            List<Tuple<string, string>> stringParams = new List<Tuple<string, string>>();
            stringParams.Add(tuple("given", firstName));
            stringParams.Add(tuple("family", lastName));

            stringParams.Add(tuple("birthdate", birthDate.ToShortDateString()));
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
