using System;
using System.Collections.Generic;
using System.Linq;
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
            Patient patient = Patient.findPatient("Jason", "Argonaut", "", "", "", "");

            List<Perscription> perscriptions = Perscription.findPerscriptions(patient.getId());
            perscriptions.ForEach(perscription => Console.WriteLine(perscription.toString() + "\n\n" + "*****" + "\n") );
            //Console.WriteLine(patient.toString());
            //Console.WriteLine("\n********\n");
            //patient = Patient.findPatient("Apollo", "Minyan", "", "", "", "");
            //Console.WriteLine(patient.toString());
        }
    }
}
