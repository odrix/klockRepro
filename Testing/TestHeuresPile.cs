using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using klockRepro.Business;

namespace Testing
{
    [TestClass]
    public class TestHeuresPile
    {
        [TestMethod]
        [TestCategory("translate uniquement les heures")]
        public void TranslateUneHeure()
        {
            TimeTranslater t = new TimeTranslater();
            string result =  t.Translate(new DateTime(2013, 3, 25, 1, 0, 0));
            Assert.AreEqual("il est une heure", result);
        }

        [TestMethod]
        [TestCategory("translate uniquement les heures")]
        public void TranslateDeuxHeures()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 2, 0, 0));
            Assert.AreEqual("il est deux heures", result);
        }

        [TestMethod]
        [TestCategory("translate uniquement les heures")]
        public void TranslateCinqHeures()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 5, 0, 0));
            Assert.AreEqual("il est cinq heures", result);
        }

        [TestMethod]
        [TestCategory("translate uniquement les heures")]
        public void TranslateMidi()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 12, 0, 0));
            Assert.AreEqual("il est midi", result);
        }

        [TestMethod]
        [TestCategory("translate uniquement les heures")]
        public void TranslateMinuit()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 0, 0, 0));
            Assert.AreEqual("il est minuit", result);
        }

        [TestMethod]
        [TestCategory("translate uniquement les heures")]
        public void TranslateTroisHeurePour15h()
        {
            TimeTranslater t = new TimeTranslater();
            string result = t.Translate(new DateTime(2013, 3, 25, 15, 0, 0));
            Assert.AreEqual("il est trois heures", result);
        }
    }
}
