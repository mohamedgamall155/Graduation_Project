using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [Required]
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TargetAcademicYear { get; set; }

        public int CommitteeID { get; set; }
        [ForeignKey("CommitteeID")]
        public virtual Committee Committee { get; set; }


        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }
    }

}
