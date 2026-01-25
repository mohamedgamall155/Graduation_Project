namespace projectweb.Models
{
    public class ReportPerson
    {
        public int ReportID { get; set; }
        public Report Report { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }

        public string Signature { get; set; }
        public DateTime SignedAt { get; set; }
    }

}
