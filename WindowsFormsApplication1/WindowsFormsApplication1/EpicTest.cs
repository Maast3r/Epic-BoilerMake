using System;
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

            Perscription.findPerscriptions(patient.getId());
            //Console.WriteLine(patient.toString());
            //Console.WriteLine("\n********\n");
            //patient = Patient.findPatient("Apollo", "Minyan", "", "", "", "");
            //Console.WriteLine(patient.toString());
        }
    }
}
