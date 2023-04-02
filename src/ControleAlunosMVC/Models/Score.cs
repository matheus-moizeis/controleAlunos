namespace ControleAlunosMVC.Models
{
    public class Score : BaseModel
    {
        public double StudentScore { get; set; }
        public DateTime DateScore { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
