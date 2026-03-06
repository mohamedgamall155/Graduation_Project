using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace projectweb.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string NationalId { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<CommitteesAssignment> CommitteesAssignments { get; set; }
        public virtual ICollection<ReportPerson> ReportPersons { get; set; }
        public virtual ICollection<Relative> Relatives { get; set; }
    }

}
