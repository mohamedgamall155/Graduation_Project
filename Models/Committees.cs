namespace projectweb.Models
{
    public class Committee
    {
        public int CommitteeID { get; set; }
        public int CommitteeNumber { get; set; }
        public int RequiredMentors { get; set; }
        public int RequiredObservers { get; set; }
        public int RequiredHeads { get; set; }

        public ICollection<CommitteesAssignment> CommitteesAssignments { get; set; }
        public ICollection<BlockCommittee> BlockCommittees { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Report> Reports { get; set; }
    }

}
