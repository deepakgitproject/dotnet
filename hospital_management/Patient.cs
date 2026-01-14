 namespace IHCMS
{
    class Patient
    {
        public int PatientId { get; }
        public string Name { get; set; }
        public int Age { get; set; }

        private string medicalHistory;

        public Patient(int id, string name, int age)
        {
            PatientId = id;
            Name = name;
            Age = age;
        }

        public void SetMedicalHistory(string history)
        {
            medicalHistory = history;
        }

        public string GetMedicalHistory()
        {
            return medicalHistory;
        }
    }

}