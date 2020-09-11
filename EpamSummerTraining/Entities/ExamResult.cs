using EpamSummerTraining.ORM;

namespace EpamSummerTraining.Entities
{
    public class ExamResult
    {
        public int Id { get; set; }

        public int ExamineeId { get; set; }

        public string Discipline { get; set; }

        public int Mark { get; set; }
    }
}
