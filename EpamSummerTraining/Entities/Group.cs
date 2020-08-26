using EpamSummerTraining.ORM;

namespace EpamSummerTraining.Entities
{
    public class Group : IDbMember
    {
        public string GroupName { get; set; }
        public int GroupCount { get; set; }
    }
}
