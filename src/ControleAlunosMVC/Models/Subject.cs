namespace ControleAlunosMVC.Models
{
    public class Subject : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Score> Scores { get; set; } = new List<Score>();
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
