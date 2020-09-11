using EpamSummerTraining.ORM;

namespace EpamSummerTraining.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int GroupHeadId { get; set; }
    }
}
