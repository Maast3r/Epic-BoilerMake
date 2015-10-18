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
                Patient filePatient = Patient.fromJson(line);
                foreach (Perscription perscription in filePatient.getPerscriptions())
                {
                    Perscription epicPerscription = Perscription.getPerscriptionFromId(perscription.getId());
                    if (perscription.changed(epicPerscription))
                    {
                        perscription.copy(epicPerscription);
                    }
                }
                patients.Add(filePatient);
            }
            file.Close();
            return patients;
        }

        // This will overright the existing storeage.
        public static void saveAllPatients(List<Patient> patients)
        {
            createFile();
            foreach (Patient patient in patients)
            {
                writePatientToStorage(patient);
            }
        }

        public static void updatePerscription(Perscription perscription)
        {
            List<Patient> patients = readFile();
            foreach (Patient patient in patients)
            {
                List<Perscription> perscriptions = patient.getPerscriptions();
                for (int k=0; k<perscriptions.Count; k++)
                {
                    if (perscriptions.ElementAt(k).getId() == perscription.getId())
                    {
                        perscriptions.RemoveAt(k);
                        perscriptions.Insert(k, perscription);
                    }
                }
            }
            saveAllPatients(patients);
        } 
    }
}
