namespace projectweb.Models
{
    public class Block
    {
        public int BlockID { get; set; }
        public string BlockName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int HallID { get; set; }
        public Hall Hall { get; set; }

        public ICollection<BlockCommittee> BlockCommittees { get; set; }
        public ICollection<Report> Reports { get; set; }
    }

}
