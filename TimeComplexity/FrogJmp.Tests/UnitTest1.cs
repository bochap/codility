using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogJmp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentsOutOfRange()
        {
            var instance = new Program();
            Assert.AreEqual(0, instance.solution(-1, 0, 0));
            Assert.AreEqual(0, instance.solution(0, -1, 0));
            Assert.AreEqual(0, instance.solution(0, 0, -1));

            Assert.AreEqual(0, instance.solution(1000000001, 0, 0));
            Assert.AreEqual(0, instance.solution(0, 1000000001, 0));
            Assert.AreEqual(0, instance.solution(0, 0, 1000000001));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInvalidArguments()
        {
            var instance = new Program();
            Assert.AreEqual(0, instance.solution(1000, 10, 0));
        }

        [TestMethod]
        public void TestValidResults()
        {
            var instance = new Program();
            Assert.AreEqual(3, instance.solution(10, 85, 30));
        }
    }
}
