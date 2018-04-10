using Microsoft.VisualStudio.TestTools.UnitTesting;
using Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Tests
{
    [TestClass()]
    public class ObservableListTests
    {
        [TestMethod()]
        public void ObservableListTest()
        {
            var testSubject = new ObservableList<int>();

            testSubject.Add(1);

            Assert.IsTrue(testSubject.IndexOf(1) != -1);
        }
    }
}