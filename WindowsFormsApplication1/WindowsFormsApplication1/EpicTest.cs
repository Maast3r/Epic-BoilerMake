using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            Patient patient = Patient.findPatient("Jason", "Argonaut", "", "", "", "");
            Console.WriteLine(patient.toString() + "\n");
            List<Perscription> perscriptions = Perscription.findPerscriptions(patient.getId());
            perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));

            string json = patient.toJson();
            Console.WriteLine(json);

            dynamic newPatient = JsonConvert.DeserializeObject<Patient>(json);
            Console.WriteLine(newPatient.toString());

            //Patient patient;
            //List<Perscription> perscriptions;

            //patient = Patient.findPatient("Apollo", "Minyan", "", "", "", "");
            //Console.WriteLine(patient.toString());
            //perscriptions = Perscription.findPerscriptions(patient.getId());
            //perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));

            //patient = Patient.findPatient("Phil", "Hermes", "", "", "", "");
            //Console.WriteLine(patient.toString());
            //perscriptions = Perscription.findPerscriptions(patient.getId());
            //perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));

            //patient = Patient.findPatient("Athena", "Pallas", "", "", "", "");
            //Console.WriteLine(patient.toString());
            //perscriptions = Perscription.findPerscriptions(patient.getId());
            //perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));


            //Console.WriteLine("\n********\n");
            //Console.WriteLine(patient.toString());
        }
    }
}
