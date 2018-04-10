using Microsoft.VisualStudio.TestTools.UnitTesting;
using Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Tests
{
    [TestClass()]
    public class DebugLoggerTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            Logger logger = new Logger();
            var list = new ObservableList<string>();
            list.Attach(logger);
            string str1 = "string1",
                str2 = "string2",
                str3 = "string3";

            list.Add(str1);
            list.Add(str2);
            list.Insert(2, str3);

            list.Remove(str1);
            list.Detach(logger);
            list.Clear();

            foreach (string entry in logger.Log)
                Trace.WriteLine(entry);

            Assert.AreEqual(logger.Log.Count, 4);
        }
    }
}