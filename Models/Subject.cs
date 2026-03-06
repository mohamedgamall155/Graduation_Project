using System.ComponentModel.DataAnnotations;

namespace projectweb.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [StringLength(200)]
        public string SubjectName { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
