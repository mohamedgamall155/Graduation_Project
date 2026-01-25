namespace projectweb.Models
{
    public class CommitteesAssignment
    {

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int CommitteeID { get; set; }
        public Committee Committee { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }

        public string AssignmentType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}
