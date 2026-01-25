using System.Data;

namespace projectweb.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<CommitteesAssignment> CommitteesAssignments { get; set; }
        public ICollection<ReportPerson> ReportPersons { get; set; }
        public ICollection<Relative> Relatives { get; set; }
    }

}
