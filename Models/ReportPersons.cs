using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class ReportPerson
    {
        [Key, Column(Order = 0)]
        public int ReportID { get; set; }
        [ForeignKey("ReportID")]
        public virtual Report Report { get; set; }

        [Key, Column(Order = 1)]
        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        public string Signature { get; set; }
        public DateTime SignedAt { get; set; } = DateTime.Now;
    }

}
