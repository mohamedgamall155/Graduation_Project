namespace projectweb.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public ICollection<ReportPerson> ReportPersons { get; set; }
    }

}
