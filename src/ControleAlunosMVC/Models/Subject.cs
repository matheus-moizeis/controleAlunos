using System.ComponentModel.DataAnnotations;

namespace ControleAlunosMVC.Models
{
    public class Subject : BaseModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Description { get; set; }
        public ICollection<Score> Scores { get; set; } = new List<Score>();
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
