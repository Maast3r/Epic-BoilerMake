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
        private string id;
        private string medication;
        private int numberOfRefills;
        private double expectedSupplyDurationValue;
        private string expectedSupplyDurationUnit;

        private int quantityRemaining;
        private string dosageInstruction;
        private bool asNeeded;

        private double timingPeriod;
        private string timingPeriodUnit;

        private List<Tuple<DateTime, string>> reminders;

        public Perscription(string id, string medication, int numberOfRefills, double expectedSupplyDurationValue, string expectedSupplyDurationUnit,
            int quantityRemaining, string dosageInstruction, bool asNeeded, double timingPeriod, string timingPeriodUnit, List<Tuple<DateTime, string>> reminders)
        {
            this.id = id;
            this.medication = medication;
            this.numberOfRefills = numberOfRefills;
            this.expectedSupplyDurationValue = expectedSupplyDurationValue;
            this.expectedSupplyDurationUnit = expectedSupplyDurationUnit;
            this.quantityRemaining = quantityRemaining;
            this.dosageInstruction = dosageInstruction;
            this.asNeeded = asNeeded;
            this.timingPeriod = timingPeriod;
            this.timingPeriodUnit = timingPeriodUnit;
            this.reminders = reminders != null ? reminders : new List<Tuple<DateTime, string>>();
        }
        // returns true if you need to get a new perscription object from epic
        public bool changed(Perscription other)
        {
            return this.medication != other.medication || this.numberOfRefills != other.numberOfRefills ||
                this.expectedSupplyDurationValue != other.expectedSupplyDurationValue ||
                this.expectedSupplyDurationUnit != other.expectedSupplyDurationUnit ||
                this.dosageInstruction != other.dosageInstruction ||
                this.asNeeded != other.asNeeded || this.timingPeriod != other.timingPeriod ||
                this.timingPeriodUnit != other.timingPeriodUnit;

        }

        public void copy(Perscription other)
        {
            this.id = other.id;
            this.medication = other.medication;
            this.numberOfRefills = other.numberOfRefills;
            this.expectedSupplyDurationValue = other.expectedSupplyDurationValue;
            this.expectedSupplyDurationUnit = other.expectedSupplyDurationUnit;
            this.quantityRemaining = other.quantityRemaining;
            this.dosageInstruction = other.dosageInstruction;
            this.asNeeded = other.asNeeded;
            this.timingPeriod = other.timingPeriod;
            this.timingPeriodUnit = other.timingPeriodUnit;
            this.reminders = other.reminders;
        }

        public string getId()
        {
            return this.id;
        }
        
        public List<Tuple<DateTime, string>> getReminders()
        {
            return this.reminders;
        }

        internal static Perscription getPerscriptionFromId(string id)
        {
            var client = new RestClient("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/");
            client.ClearHandlers();
            client.AddHandler("application/xml", new XmlDeserializer());
            client.AddHandler("text/xml", new XmlDeserializer());

            var request = new RestRequest("MedicationPrescription/" + id);

            request.RequestFormat = DataFormat.Xml;

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(client.BuildUri(request));
            //if (content == "")
            //{
            //    return perscriptions;
            //}

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            return getPerscriptionFromJson(json.MedicationPrescription, id);
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
            if (content == "")
            {
                return perscriptions;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            json = json.Bundle.entry;
            if (json != null)
            {
                if (json.Count > 1)
                {
                    foreach (dynamic perscriptionJson in json)
                    {
                        string id = perscriptionJson.link.url["@value"];
                        id = id.Replace("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/MedicationPrescription/", "");
                        Perscription perscription = getPerscriptionFromJson(perscriptionJson.resource.MedicationPrescription, id);
                        perscriptions.Add(perscription);
                    }
                }
                else
                {
                    string id = json.link.url["@value"];
                    id = id.Replace("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/MedicationPrescription/", "");
                    Perscription perscription = getPerscriptionFromJson(json.resource.MedicationPrescription, id);
                    perscriptions.Add(perscription);
                }
            }
            return perscriptions;

        }

        private static Perscription getPerscriptionFromJson(dynamic json, string id)
        {
            string medication = json.medication.display["@value"];
            Console.WriteLine(medication);
            int numberOfRefills = int.Parse((string)json.dispense.numberOfRepeatsAllowed["@value"]);
            double expectedSupplyDurationValue = double.Parse((string)json.dispense.expectedSupplyDuration.value["@value"]);
            string expectedSupplyDurationUnit = json.dispense.expectedSupplyDuration.units["@value"];

            int quantityRemaining = int.Parse((string)json.dispense.quantity.value["@value"]);
            string dosageInstruction = json.dosageInstruction.text["@value"];
            bool asNeeded = bool.Parse((string)json.dosageInstruction.asNeededBoolean["@value"]);

            double timingPeriod = double.Parse((string)json.dosageInstruction.scheduledTiming.repeat.period["@value"]);
            string timingPeriodUnit = json.dosageInstruction.scheduledTiming.repeat.periodUnits["@value"];

            return new Perscription(id, medication, numberOfRefills, expectedSupplyDurationValue, expectedSupplyDurationUnit,
                quantityRemaining, dosageInstruction, asNeeded, timingPeriod, timingPeriodUnit, null);
        }

        public bool getARefill(bool keepOldPills)
        {
            if (this.numberOfRefills <= 0)
            {
                return false;
            }
            int refillAmount = (int)(this.expectedSupplyDurationValue / this.timingPeriod);
            if (keepOldPills)
            {
                this.quantityRemaining += refillAmount;
            }
            else
            {
                this.quantityRemaining = refillAmount;
            }
            this.numberOfRefills--;
            FileStorage.updatePerscription(this);
            return true;
        }

        public bool takeAPill()
        {
            if (this.quantityRemaining <= 0)
            {
                return false;
            }
            this.quantityRemaining--;
            FileStorage.updatePerscription(this);
            return true;
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
