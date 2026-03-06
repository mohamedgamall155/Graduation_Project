using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("PersonId")]
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }
    }
}
