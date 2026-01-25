namespace projectweb.Models
{
    public class Hall
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }

        public int HallSupervisorID { get; set; }
        public Person HallSupervisor { get; set; }

        public ICollection<Block> Blocks { get; set; }
    }

}
