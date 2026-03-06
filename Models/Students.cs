using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [Required]
        [StringLength(20)]
        public string NationalId { get; set; }
        public int AcademicYear { get; set; }
        public int SeatNumber { get; set; }

        public int? CommitteeId { get; set; }
        [ForeignKey("CommitteeId")]
        public virtual Committee Committee { get; set; }
        public virtual ICollection<Relative> Relatives { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }

}
