using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class CommitteesAssignment
    {

        [Key]
        public int AssignmentID { get; set; }
        public int PersonID { get; set; }
        public int CommitteeID { get; set; }
        public int RoleID { get; set; }
        public string AssignmentType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoleType { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
        [ForeignKey("CommitteeID")]
        public virtual Committee Committee { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

    }

}
