namespace projectweb.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string SubjectName { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int YearLevel { get; set; }

        public int CommitteeID { get; set; }
        public Committee Committee { get; set; }
    }

}
