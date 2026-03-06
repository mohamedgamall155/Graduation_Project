using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Block
    {
        [Key]
        public int BlockID { get; set; }
        public string BlockName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int HallID { get; set; }
        [ForeignKey("HallID")]
        public Hall Hall { get; set; }

        public virtual ICollection<BlockCommittee> BlockCommittees { get; set; }
        public virtual ICollection<Committee> Committees { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }

}
