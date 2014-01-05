using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PermMissingElem.Tests
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
        public void TestArgumentOutOfRange()
        {
            var instance = new Program();
            var list = new int[100002];
            Assert.AreEqual(0, instance.solution(list));
        }

        [TestMethod]
        public void TestLargeArraySuccess()
        {
            var instance = new Program();
            var list = new List<int>();
            for (var count = 1; count <= 100000; count++)
            {
                list.Add(count);
            }
            list.Remove(10001);

            Assert.AreEqual(10001, instance.solution(list.ToArray()));
        }

        [TestMethod]
        public void TestSuccess()
        {
            var instance = new Program();
            var list = new int[] { 2, 3, 1, 5};
            Assert.AreEqual(4, instance.solution(list));
        }
    }
}
