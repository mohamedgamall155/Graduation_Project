using System.ComponentModel.DataAnnotations;

namespace projectweb.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }


        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<CommitteesAssignment> CommitteesAssignments { get; set; }
        public virtual ICollection<ReportPerson> ReportPersons { get; set; }
    }

}
