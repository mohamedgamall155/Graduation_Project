using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Notes { get; set; }

        public int BlockID { get; set; }
        [ForeignKey("BlockID")]
        public virtual Block Block { get; set; }

        public int CommitteeID { get; set; }
        [ForeignKey("CommitteeId")]
        public Committee Committee { get; set; }

        public ICollection<ReportPerson> ReportPersons { get; set; }
    }

}
