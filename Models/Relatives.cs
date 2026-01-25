namespace projectweb.Models
{
    public class Relative
    {
        public int RelativeId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public string RelationType { get; set; }
    }

}
