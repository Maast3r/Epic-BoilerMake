using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class FileStorage
    {
        public static readonly string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "storage.txt";


        public static void writePatientToStorage(Patient patient)
        {
            StreamWriter file = new StreamWriter(filePath, true);
            file.WriteLine(patient.toJson());
            file.Close();
        }

        public static void createFile()
        {
            Console.WriteLine(filePath);
            new StreamWriter(filePath).Close();
        }

        public static List<Patient> readFile()
        {
            List<Patient> patients = new List<Patient>();
            StreamReader file = new StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                patients.Add(Patient.fromJson(line));
            }
            file.Close();
            return patients;
        }
    }
}
