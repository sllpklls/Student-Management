namespace QuanLySinhVien
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Application.Run(new SignIn());
            //Application.Run(new AddStudent());
            //Application.Run(new MainInterface());
            //Application.Run(new AddMajors());
            //pplication.Run(new AddClass());
            //Application.Run(new ListFeatureSchool());
            //Application.Run(new AddStudent());
            //Application.Run(new AddTeacher());



        }

    }
    public class ClassX
    {
        public string NameMajors { get; set; }
        public string NameClass { get; set; } 
        private string Manager { get; set; }
        private string Leader { get; set; }
        public ClassX(string _NameMajors, string _NameClass, string _Manager, string _Leader)
        {
            NameMajors = _NameMajors;
            NameClass = _NameClass;
            Manager = _Manager;
            Leader = _Leader;
        }
    }
    public class MajorsX
    {
        public string IDMajors { get; set; }
        public string NameMajors { set; get; }
        public string Amount { get; set; }
        public string Note { get; set; }
        public MajorsX(string _IDMajors, string _NameMajors, string _Amount, string _Note)
        {
            IDMajors = _IDMajors;
            NameMajors= _NameMajors;
            Amount= _Amount;
            Note= _Note;
        }
    }
    public class Student
    {
        public string IDStudent { get; set; }
        public string NameStudent { get; set; }
        public string ClassSt { get; set; }
        private string BirthDaySt { get; set; }
        private string SexSt { get; set; }
        private string AddressStudent { get; set; }
        private string NumberPhoneSt { get; set; }
        public Student(string _IDStudent, string _NameStudent, string _ClassSt, string _BirthDaySt, string _SexSt, string _AddressStudent, string _NumberPhoneSt)
        {
            IDStudent = _IDStudent;
            NameStudent = _NameStudent;
            ClassSt = _ClassSt;
            BirthDaySt = _BirthDaySt;
            SexSt = _SexSt;
            AddressStudent = _AddressStudent;
            NumberPhoneSt = _NumberPhoneSt;
        }
        public string inforStudent()
        {
            string gt;
            if (SexSt == "True") gt = "Nam";
            else gt = "Nữ";
            return $"{IDStudent}-{NameStudent}-{gt}";
        }
        public string inforStudentFull()
        {
            string gt;
            if (SexSt == "True") gt = "Nam";
            else gt = "Nữ";
            return $"{IDStudent}-{NameStudent}-{gt}-{ClassSt}-{BirthDaySt}-{AddressStudent}-{NumberPhoneSt}";
        }
    }
    public class Teacher
    {
        public string IDTeacher { get; set; }
        private string NameTeacher { get; set; }
        private string SexTe { get; set; }
        private string SubjectTeacher { get; set; }
        private string NumberPhoneTe { get; set; }
        public Teacher(string _IDTeacher, string _NameTeacher, string _SexTe, string _SubjectTeacher, string _NumberPhoneTe)
        {
            IDTeacher = _IDTeacher;
            NameTeacher = _NameTeacher;
            SexTe = _SexTe;
            SubjectTeacher = _SubjectTeacher;
            NumberPhoneTe = _NumberPhoneTe;
        }
        public string inforTeacherFull()
        {
            string gt;
            if (SexTe == "True") gt = "Nam";
            else gt = "Nữ";
            return $"{IDTeacher}-{NameTeacher}-{gt}-{SubjectTeacher}-{NumberPhoneTe}";
        }
        public string inforTeacher()
        {
            string gt;
            if (SexTe == "True") gt = "Nam";
            else gt = "Nữ";
            return $"{IDTeacher}-{NameTeacher}-{gt}";
        }
    }
}