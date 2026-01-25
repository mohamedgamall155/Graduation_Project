namespace projectweb.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }

        public int BlockID { get; set; }
        public Block Block { get; set; }

        public int CommitteeID { get; set; }
        public Committee Committee { get; set; }

        public ICollection<ReportPerson> ReportPersons { get; set; }
    }

}
