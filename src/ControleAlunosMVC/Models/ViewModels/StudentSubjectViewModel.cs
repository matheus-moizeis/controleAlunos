namespace ControleAlunosMVC.Models.ViewModels
{
    public class StudentSubjectViewModel
    {
        public StudentSubject? StudentSubject { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
