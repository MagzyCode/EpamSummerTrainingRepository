using EpamSummerTraining.ORM;

namespace EpamSummerTraining.Entities
{
    public class ExamResult : IDbMember
    {
        // экзаменуемый
        public Student Examinee { get; set; }

        public Subject Discipline { get; set; }

        public int Mark { get; set; }
    }
}
