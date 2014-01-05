using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TapeEquilibrium.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArgumentNull()
        {
            var instance = new Program();
            Assert.AreEqual(0, instance.solution(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentOutOfLowerRange()
        {
            var instance = new Program();
            var list = new int[1];
            Assert.AreEqual(0, instance.solution(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentOutOfUpperRange()
        {
            var instance = new Program();
            var list = new int[100001];
            Assert.AreEqual(0, instance.solution(list));
        }

        [TestMethod]
        public void TestSuccess()
        {
            var instance = new Program();
            var list = new int[] { 3, 1, 2, 4, 3};
            Assert.AreEqual(1, instance.solution(list));
        }


        [TestMethod]
        public void TestSuccess2Elements()
        {
            var instance = new Program();
            var list = new int[] { 3, 1 };
            Assert.AreEqual(2, instance.solution(list));
        }
    }
}
