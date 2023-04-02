using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControleAlunosMVC.Models
{
    public class StudentSubject : BaseModel
    {
        [Display(Name = "Aluno")]
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        [Display(Name = "Disciplina")]
        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }

        [Display(Name = "Observação")]
        public string Obersavation { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime DateStudentSubject { get; set; }

    }
}
