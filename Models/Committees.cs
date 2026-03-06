using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Committee
    {
        [Key]
        public int CommitteeID { get; set; }
        public int CommitteeNumber { get; set; }
        public int RequiredMentors { get; set; }
        public int RequiredObservers { get; set; }
        public int RequiredHeads { get; set; }
        public int NumberOfStudent { get; set; }
        public string StatusOfCommittee { get; set; }

        public int BlockID { get; set; }
        [ForeignKey("BlockID")]
        public virtual Block Block { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<CommitteesAssignment> CommitteesAssignments { get; set; }
        public virtual ICollection<BlockCommittee> BlockCommittees { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }

}
