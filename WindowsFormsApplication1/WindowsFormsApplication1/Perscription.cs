using System;
using System.Collections.Generic;
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
            List<Perscription> perscriptions = new List<Perscription>();

            var client = new RestClient("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/");
            client.ClearHandlers();
            client.AddHandler("application/xml", new XmlDeserializer());
            client.AddHandler("text/xml", new XmlDeserializer());

            var request = new RestRequest("MedicationPrescription");
            request.AddParameter("patient", patientId);
            request.AddParameter("status", "active");

            request.RequestFormat = DataFormat.Xml;

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            json = json.Bundle.entry.resource;
            Perscription perscription = getPerscriptionFromJson(json.MedicationPrescription);

            perscriptions.Add(perscription);
            return perscriptions;

        }

        private static Perscription getPerscriptionFromJson(dynamic json)
        {
            string medication = json.medication.display["@value"];
            int numberOfRefills = int.Parse((string)json.dispense.numberOfRepeatsAllowed["@value"]);
            double expectedSupplyDurationValue = double.Parse((string)json.dispense.expectedSupplyDuration.value["@value"]);
            string expectedSupplyDurationUnit = json.dispense.expectedSupplyDuration.units["@value"];

            int quantityRemaining = int.Parse((string)json.dispense.quantity.value["@value"]);
            string dosageInstruction = json.dosageInstruction.text["@value"];
            bool asNeeded = bool.Parse((string)json.dosageInstruction.asNeededBoolean["@value"]);

            double timingPeriod = double.Parse((string)json.dosageInstruction.scheduledTiming.repeat.period["@value"]);
            string timingPeriodUnit = json.dosageInstruction.scheduledTiming.repeat.periodUnits["@value"];

            return new Perscription(medication, numberOfRefills, expectedSupplyDurationValue, expectedSupplyDurationUnit,
                quantityRemaining, dosageInstruction, asNeeded, timingPeriod, timingPeriodUnit);
        }
        public string toString()
        {
            return "medication: " + this.medication + "\nnumberOfRefills: " + this.numberOfRefills + "\nexpectedSupplyDurationValue: " +
                this.expectedSupplyDurationValue + " " + this.expectedSupplyDurationUnit +
                "\nquantityRemaining: " + this.quantityRemaining + "\ndosageInstruction: " + this.dosageInstruction + 
                "\nasNeeded: " + this.asNeeded + "\ntimingPeriod: " + this.timingPeriod + " " + this.timingPeriodUnit;
        }
    }
}
