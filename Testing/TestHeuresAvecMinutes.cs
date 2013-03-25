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
            result = t.Translate(new DateTime(2013, 3, 25, 2, 3, 0));
            Assert.AreEqual("il est deux heures cinq", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 7, 0));
            Assert.AreEqual("il est deux heures cinq", result);
        }

        [TestMethod]
        public void TranslateDeuxHeureDix()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 2, 10, 0));
            Assert.AreEqual("il est deux heures dix", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 8, 0));
            Assert.AreEqual("il est deux heures dix", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 12, 0));
            Assert.AreEqual("il est deux heures dix", result);
        }

        [TestMethod]
        public void TranslateDeuxHeureEtQuart()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 2, 15, 0));
            Assert.AreEqual("il est deux heures et quart", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 13, 0));
            Assert.AreEqual("il est deux heures et quart", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 16, 0));
            Assert.AreEqual("il est deux heures et quart", result);
        }

        [TestMethod]
        public void TranslateTroisHeureMoinsCinq()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 2, 57, 0));
            Assert.AreEqual("il est trois heures moins cinq", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 57, 0));
            Assert.AreEqual("il est trois heures moins cinq", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 53, 0));
            Assert.AreEqual("il est trois heures moins cinq", result);
        }

        [TestMethod]
        public void Translate3heures()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 3, 0, 0));
            Assert.AreEqual("il est trois heures", result);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 58, 0));
            Assert.AreEqual("il est trois heures", result);
            result = t.Translate(new DateTime(2013, 3, 25, 3, 2, 0));
            Assert.AreEqual("il est trois heures", result);
        }
    }
}
