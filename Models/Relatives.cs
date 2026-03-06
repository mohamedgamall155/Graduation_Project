using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Relative
    {
        [Key]
        public int RelativeId { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [Required]
        [StringLength(50)]
        public string RelationType { get; set; }
        public int AcademicYear { get; set; }
    }

}
