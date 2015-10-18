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
            Console.WriteLine("");
            ////string json = patient.toJson();
            ////Console.WriteLine(json);
            //FileStorage.createFile();
            //FileStorage.writePatientToStorage(patient);

            //patient = Patient.findPatient("Apollo", "Minyan", "", "", "", "");
            //Console.WriteLine(patient.toString());
            //perscriptions = Perscription.findPerscriptions(patient.getId());
            //perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));

            //FileStorage.writePatientToStorage(patient);

            //patient = Patient.findPatient("Phil", "Hermes", "", "", "", "");
            //Console.WriteLine(patient.toString());
            //perscriptions = Perscription.findPerscriptions(patient.getId());
            //perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));

            //FileStorage.writePatientToStorage(patient);

            //patient = Patient.findPatient("Athena", "Pallas", "", "", "", "");
            //Console.WriteLine(patient.toString());
            //perscriptions = Perscription.findPerscriptions(patient.getId());
            //perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n"));

            //FileStorage.writePatientToStorage(patient);

            //List<Patient> patients = FileStorage.readFile();
            ////FileStorage.saveAllPatients(patients);
            //Perscription perscription = patients.ElementAt(0).getPerscriptions().ElementAt(0);
            ////perscription.getARefill(true);
            ////perscription.takeAPill();
            //Console.WriteLine(perscription.getMustRefillDate());
            //Console.WriteLine(perscription.getTotalNumberOfPills());


            //Console.WriteLine("\n********\n");
            //Console.WriteLine(patient.toString());
        }
    }
}
