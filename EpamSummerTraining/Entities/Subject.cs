using EpamSummerTraining.ORM;

namespace EpamSummerTraining.Entities
{
    public class Subject : IDbMember
    {
        
        public string DisciplineName { get; set; }
        public string FullNameOfTeacher { get; set; }
    }
}
