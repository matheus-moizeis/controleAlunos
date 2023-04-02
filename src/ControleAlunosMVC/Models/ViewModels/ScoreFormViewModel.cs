namespace ControleAlunosMVC.Models.ViewModels
{
    public class ScoreFormViewModel
    {
        public Score? Score { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Score> Scores { get; set; }

    }
}
