using System;
using System.Xml;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class EpicTest
    {
        public EpicTest()
        {
            Console.WriteLine("");
            Console.WriteLine("Starting test");
            Console.WriteLine("");
            startTest();
            Console.WriteLine("");
            Console.WriteLine("Ended test");
            Application.Exit();
        }

        public void startTest()
        {
            var client = new RestClient("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/");
            client.ClearHandlers();
            client.AddHandler("application/xml", new XmlDeserializer());
            client.AddHandler("text/xml", new XmlDeserializer());

            var patientId = "Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB";
            var request = new RestRequest("Patient/" + patientId);
            request.RequestFormat = DataFormat.Xml;

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            json = json.Patient;

            //Console.WriteLine(json);
            Console.WriteLine("");
            Console.WriteLine("name = " + json.name.given["@value"] + " " + json.name.family["@value"]);
        }
    }
}
