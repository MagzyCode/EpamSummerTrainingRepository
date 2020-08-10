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
        private BinaryTree<Test.TestResult> _tree;
        public const int TEST_NUMBER_OF_ELEMENTS = 15;

        [SetUp]
        public void Setup()
        {
            _tree = new BinaryTree<Test.TestResult>();
            for (int i = 0; i < TEST_NUMBER_OF_ELEMENTS; i++)
            {

                var test = new Test.TestResult()
                {
                    StudentNumber = i * 10 + 1,
                    Mark = new Random().Next(Test.TestResult.MIN_TEST_RESULT, Test.TestResult.MAX_TEST_RESULT),
                    TestName = Guid.NewGuid().ToString(),
                    DateÎfÑompletion = DateTime.Now
                };
                _tree.Add(test);
            }
        }
        
        [TestCase(/*10, */ExpectedResult = 15)]
        //[TestCase(30, ExpectedResult = 30)]
        //[TestCase(]
        // [Test(ExpectedResult = 50)]
        public int TestBinaryTreeAddition()
        {
            return _tree.ToList().Count;
        }

        [TestCase(/*10, */ExpectedResult = true)]
        //[TestCase(/*50, */ExpectedResult = true)]
        // [Test(ExpectedResult = true)]
        public bool TestBinaryTreeGetMinAndMax()
        {
            var min = _tree.GetMin(_tree.Root).StudentNumber;
            var max = _tree.GetMax(_tree.Root).StudentNumber;

            var minCor = _tree.ToList().Select(i => i.StudentNumber).Min();
            var maxCor = _tree.ToList().Select(i => i.StudentNumber).Max();
            if ((min == minCor) && (max == maxCor))
            {
                return true;
            }
            return false;
        }

        [TestCase(ExpectedResult = 14)]
        public int TestBinaryTreeRemove()
        {
            var randomNumber = new Random().Next(1, _tree.Count);
            var getRandomElement = _tree.ToList().Skip(randomNumber).Take(1).ToList();
            _tree.Remove(getRandomElement[0]);
            return _tree.Count;
        }

        [TestCase(ExpectedResult = true)]
        public bool TestBinatyTreeBalancing()
        {
            // var ass = _tree.GetDepth(_tree.Root.Right);
            //var i = _tree.GetDepth(_tree.Root);
            //var tmp = _tree.IsTreeBalanced(_tree);
            // var i = _tree.GetBalanceFactor(_tree.Root);
            // var root = _tree.Root;
            _tree.Rebalance();
            var i = _tree.GetBalanceFactor(_tree.Root);
            // var result = _tree.IsTreeBalanced(_tree);
            return i < 2;

        }
    }
}