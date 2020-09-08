using EpamSummerTraining.ORM;
using System;

namespace EpamSummerTraining.Entities
{
    public class ExamSchedule : IDbMember
    {
        public string GroupName { get; set; }

        public string Discipline { get; set; }

        public DateTime ExamDate { get; set; }

        public string CheckingKnowledgeForm { get; set; }
    }
}
