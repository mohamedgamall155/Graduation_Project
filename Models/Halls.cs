using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectweb.Models
{
    public class Hall
    {
        [Key]
        public int HallId { get; set; }
        [Required]
        [StringLength(100)]
        public string HallName { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }

        public int HallSupervisorID { get; set; }
        [ForeignKey("HallSupervisorID")]
        public virtual Person HallSupervisor { get; set; }

        public virtual  ICollection<Block> Blocks { get; set; }
    }

}
