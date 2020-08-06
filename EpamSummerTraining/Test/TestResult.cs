using ExerciseFirst.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseFirst.Test
{
    public class TestResult : IBinaryTreeElement<TestResult>
    {
        private protected int _studentNumber;
        private protected double _mark;
        private protected string _testName;
        private protected DateTime _dateОfСompletion;

        public const double MIN_TEST_RESULT = 0.0;
        public const double MAX_TEST_RESULT = 100.0;
        public const int MAX_TEST_NAME_LENGTH = 500;
        public static readonly DateTime MIN_TEST_DATE = new DateTime(1970, 1, 1, 0, 0, 0);

        public TestResult()
        { }

        public TestResult(int studentNumber, string testName, DateTime dateOfCompletion, double mark)
        {
            StudentNumber = studentNumber;
            TestName = testName;
            DateОfСompletion = dateOfCompletion;
            Mark = mark;
        }

        public int StudentNumber
        {
            get
            {
                return _studentNumber;
            }

            set
            {
                if (value >= 1)
                {
                    _studentNumber = value;
                }
                else
                {
                    throw new Exception("Невозможное значение для студенческого номера.");
                }
            }
        }
        public double Mark
        {
            get
            {
                return _mark;
            }

            set
            {
                if ((value >= MIN_TEST_RESULT) && (value <= MAX_TEST_RESULT))
                {
                    _mark = value;
                }
                else
                {
                    throw new Exception("Невозможное значение для оценки за тест.");
                }
            }
        }
        public DateTime DateОfСompletion
        {
            get
            {
                return _dateОfСompletion;
            }

            set
            {
                _dateОfСompletion = value <= MIN_TEST_DATE
                    ? throw new Exception("Некорректная дата проведения тестирования")
                    : value;
            }
        }
        public string TestName
        {
            get
            {
                return _testName.Clone() as string;
            }

            set
            {
                if (value != null)
                {
                    _testName = value.Length > MAX_TEST_NAME_LENGTH
                        ? throw new Exception("Превышено максимальное количество символов для незвания теста.")
                        : value;
                }
            }

        }
        public TestResult Left { get; set; }
        public TestResult Right { get; set; }

        public static bool operator >(TestResult left, TestResult right)
        {
            if ((left == null) || (right == null))
            {
                return false;
            }

            var result = left.StudentNumber > right.StudentNumber;
            return result;
        }
        public static bool operator <(TestResult left, TestResult right)
        {
            if (!(left > right))
            {
                var result = left.StudentNumber != right.StudentNumber;
                return result;
            }
            return false;

        }


    }
}
