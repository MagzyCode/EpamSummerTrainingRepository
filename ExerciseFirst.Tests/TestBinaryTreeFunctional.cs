using ExerciseFirst.Collection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using ExerciseFirst.Test;
using System.Linq;

namespace ExerciseFirst.Tests
{
    [TestFixture]
    public class TestBinaryTreeFunctional
    {
        [TestCase(10, ExpectedResult = 10)]
        [TestCase(30, ExpectedResult = 30)]
        public int TestBinaryTreeAddition(int numberOfElements)
        {
            var tree = new BinaryTree<Test.TestResult>();
            for (int i = 0; i < numberOfElements; i++)
            {
                var test = new Test.TestResult()
                {
                    StudentNumber = new Random().Next(0, int.MaxValue),
                    Mark = new Random().Next(Test.TestResult.MIN_TEST_RESULT, Test.TestResult.MAX_TEST_RESULT),
                    TestName = Guid.NewGuid().ToString(),
                    DateÎfÑompletion = DateTime.Now
                };
                tree.Add(test);
            }
            
            return tree.ToList().Count;

        }

        [TestCase(10, ExpectedResult = true)]
        [TestCase(50, ExpectedResult = true)]
        public bool TestBinaryTreeGetMinAndMax(int numberOfElements)
        {
            var tree = new BinaryTree<Test.TestResult>();
            for (int i = 0; i < numberOfElements; i++)
            {
                var test = new Test.TestResult()
                {
                    StudentNumber = new Random().Next(0, int.MaxValue),
                    Mark = new Random().Next(Test.TestResult.MIN_TEST_RESULT, Test.TestResult.MAX_TEST_RESULT),
                    TestName = Guid.NewGuid().ToString(),
                    DateÎfÑompletion = DateTime.Now
                };
                tree.Add(test);
            }
            var min = tree.GetMin(tree.Root).StudentNumber;
            var max = tree.GetMax(tree.Root).StudentNumber;

            var minCor = tree.ToList().Select(i => i.StudentNumber).Min();
            var maxCor = tree.ToList().Select(i => i.StudentNumber).Max();
            if ((min == minCor) && (max == maxCor))
            {
                return true;
            }
            return false;
        }
    }
}