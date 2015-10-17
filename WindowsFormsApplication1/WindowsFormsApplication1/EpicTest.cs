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
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Ended test");
            Application.Exit();
        }

        public void startTest()
        {
            Patient patient = Patient.findPatient("Jason", "Argonaut", new DateTime(0), "", "", "");
            Console.WriteLine(patient);
            //var client = new RestClient("https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/");
            //client.ClearHandlers();
            //client.AddHandler("application/xml", new XmlDeserializer());
            //client.AddHandler("text/xml", new XmlDeserializer());

            ////var patientId = "Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB";
            ////var request = new RestRequest("Patient/" + patientId);
            //var request = new RestRequest("Patient");
            //request.AddParameter("family", "Argonaut");
            //request.AddParameter("Given", "Jason");
              
            //request.RequestFormat = DataFormat.Xml;
            //Console.WriteLine(client.BuildUri(request));

            //IRestResponse response = client.Execute(request);
            //var content = response.Content;

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(content);
            //string jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            //dynamic json = JsonConvert.DeserializeObject(jsonString);
            ////json = json.Patient;

            //Console.WriteLine("");
            //Console.WriteLine(json);
            ////Console.WriteLine("name = " + json.name.given["@value"] + " " + json.name.family["@value"]);
        }
    }
}
