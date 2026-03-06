using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }
        [Required]
        public string Action { get; set; }  
        public string TableAffected { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
