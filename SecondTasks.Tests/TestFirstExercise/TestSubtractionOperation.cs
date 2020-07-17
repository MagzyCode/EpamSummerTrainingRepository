﻿using SecondTask.FirstExercise;
using Xunit;

namespace SecondTasks.Tests.TestFirstExercise
{
    public class TestSubtractionOperation
    {
        [Fact]
        public void SubtractionOperation_vector_0_0_0_and_vector_5_5_5_vectormin5_min5_min5expected()
        {
            var expected = new Vector(-5, -5, -5);

            var firstVector = new Vector(0, 0, 0);
            var secondVector = new Vector(5, 5, 5);
            var actual = firstVector - secondVector;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractionOperation_vector_min3_145_1_and_vector_985and5_min5_14and45_()
        {
            var expected = new Vector(-988.5, 150, -13.45);

            var firstVector = new Vector(-3, 145, 1);
            var secondVector = new Vector(985.5, -5, 14.45);
            var actual = firstVector - secondVector;

            Assert.Equal(expected, actual);
        }
    }
}
