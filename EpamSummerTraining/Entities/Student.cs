using EpamSummerTraining.ORM;
using System;

namespace EpamSummerTraining.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBorn { get; set; }
        public string StudentGroup { get; set; }
    }
}
