namespace ControleAlunosMVC.Models
{
    public class Student : BaseModel
    {
        public string Name { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public ICollection<Score> Scores { get; set; } = new List<Score>();
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
