using klockRepro.Business;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class TestHeuresAvecMinutes
    {

        [TestMethod]
        public void TranslateDeuxHeureCinq()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 2, 5, 0));
            Assert.AreEqual("il est deux heures cinq", result);
        }
    }
}
