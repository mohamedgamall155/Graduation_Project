namespace projectweb.Models
{
    public class BlockCommittee
    {
        public int BlockID { get; set; }
        public Block Block { get; set; }

        public int CommitteeID { get; set; }
        public Committee Committee { get; set; }
    }

}
