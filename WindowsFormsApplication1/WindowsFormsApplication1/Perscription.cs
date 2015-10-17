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
    class Perscription
    {
        private string medication;
        private int numberOfRefills;
        private double expectedSupplyDurationValue;
        private string expectedSupplyDurationUnit;

        private int quantityRemaining;
        private string dosageInstruction;
        private bool asNeeded;

        private double timingPeriod;
        private string timingPeriodUnit;

        public Perscription(string medication, int numberOfRefills, double expectedSupplyDurationValue, string expectedSupplyDurationUnit,
            int quantityRemaining, string dosageInstruction, bool asNeeded, double timingPeriod, string timingPeriodUnit)
        {
            this.medication = medication;
            this.numberOfRefills = numberOfRefills;
            this.expectedSupplyDurationValue = expectedSupplyDurationValue;
            this.expectedSupplyDurationUnit = expectedSupplyDurationUnit;
            this.quantityRemaining = quantityRemaining;
            this.dosageInstruction = dosageInstruction;
            this.asNeeded = asNeeded;
            this.timingPeriod = timingPeriod;
            this.timingPeriodUnit = timingPeriodUnit;
        }

        public static List<Perscription> findPerscriptions(string patientId)
        {
            var client = new RestClient("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/");
            client.ClearHandlers();
            client.AddHandler("application/xml", new XmlDeserializer());
            client.AddHandler("text/xml", new XmlDeserializer());

            var request = new RestRequest("Patient");
            request.RequestFormat = DataFormat.Xml;

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            Console.WriteLine(json);

            return null;

        }

    }
}
