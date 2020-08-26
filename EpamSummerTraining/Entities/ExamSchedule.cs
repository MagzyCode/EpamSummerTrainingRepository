using EpamSummerTraining.ORM;
using System;

namespace EpamSummerTraining.Entities
{
    public class ExamSchedule : IDbMember
    {
        public Group Group { get; set; }

        public Subject Discipline { get; set; }

        public DateTime ExamDate { get; set; }
    }
}
