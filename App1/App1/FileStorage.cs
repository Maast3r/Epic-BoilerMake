
using System.Collections.Generic;
using System.IO;
namespace WindowsFormsApplication1
{
    class FileStorage
    {
        public static readonly string filePath = Directory.GetCurrentDirectory() + "storage.txt";


        public static void writePatientToStorage(Patient patient)
        {
            File.AppendAllLines(filePath, new string[] { patient.toJson() });
        }

        public static void createFile()
        {
            File.Create(filePath);
        }

        public static List<Patient> readFile()
        {
            List<Patient> patients = new List<Patient>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
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
                for (int k = 0; k < perscriptions.Count; k++)
                {
                    if (perscriptions[k].getId() == perscription.getId())
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
