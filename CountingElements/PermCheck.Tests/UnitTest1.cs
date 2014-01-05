using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PermCheck.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsPermutation()
        {
            var instance = new Program();
            Assert.AreEqual(1, instance.solution(new int[]{ 4, 1, 3, 2}));
        }

        [TestMethod]
        public void TestIsNotPermutation()
        {
            var instance = new Program();
            Assert.AreEqual(0, instance.solution(new int[] { 4, 1, 3 }));
        }

        [TestMethod]
        public void TestSingleIsPermutation()
        {
            var instance = new Program();
            Assert.AreEqual(1, instance.solution(new int[] { 4 }));
        }

        [TestMethod]
        public void TestSingleLargeIsPermutation()
        {
            var instance = new Program();
            Assert.AreEqual(1, instance.solution(new int[] { 1000000000 }));
        }

        [TestMethod]
        public void TestDoubleIsPermutation()
        {
            var instance = new Program();
            Assert.AreEqual(1, instance.solution(new int[] { 4, 3 }));
        }
    }
}
