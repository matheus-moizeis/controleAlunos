using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAlunosMVC.Models
{
    public class Score : BaseModel
    {
        [Display(Name = "Nota")]
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double StudentScore { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime DateScore { get; set; }
        
        [Display(Name = "Aluno")]
        public int StudentId { get; set; }
       
        public Student? Student { get; set; }

        [Display(Name = "Disciplina")]
        public int SubjectId { get; set; }
        
        public Subject? Subject { get; set; }

    }
}
