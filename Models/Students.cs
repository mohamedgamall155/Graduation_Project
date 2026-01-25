namespace projectweb.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public int AcademicYear { get; set; }

        public ICollection<Relative> Relatives { get; set; }
    }

}
