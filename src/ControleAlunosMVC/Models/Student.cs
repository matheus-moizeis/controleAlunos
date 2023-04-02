using System.ComponentModel.DataAnnotations;

namespace ControleAlunosMVC.Models
{
    public class Student : BaseModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="{0} é um campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Cep { get; set; }
        
        [Display(Name = "Rua")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Street { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Neighborhood { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string State { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Country { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public string Email { get; set; }
        public ICollection<Score> Scores { get; set; } = new List<Score>();
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
