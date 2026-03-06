using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class BlockCommittee
    {
        [Key, Column(Order = 0)]
        public int BlockID { get; set; }
        [ForeignKey("BlockID")]
        public Block Block { get; set; }
        [Key, Column(Order = 1)]
        public int CommitteeID { get; set; }
        [ForeignKey("CommitteeID")]
        public Committee Committee { get; set; }
    }

}
