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
        public void TranslateUneHeure()
        {
            TimeTranslater t = new TimeTranslater();
            IndexLengthWord[] result =  t.TranslateToIndex (new DateTime(2013, 3, 25, 1, 0, 0));
            Assert.AreEqual(t.une, result[2]);
            Assert.AreEqual(t.heure, result[3]);
        }

        [TestMethod]
        public void TranslateDeuxHeures()
        {
            TimeTranslater t = new TimeTranslater();
            IndexLengthWord[] result = t.TranslateToIndex(new DateTime(2013, 3, 25, 2, 0, 0));
            Assert.AreEqual(t.deux, result[2]);
            Assert.AreEqual(t.heures, result[3]);
        }

        [TestMethod]
        public void TranslateCinqHeures()
        {
            TimeTranslater t = new TimeTranslater();
            IndexLengthWord[] result = t.TranslateToIndex(new DateTime(2013, 3, 25, 5, 0, 0));
            Assert.AreEqual(t.cinqh, result[2]);
            Assert.AreEqual(t.heures, result[3]);
        }

        [TestMethod]
        public void TranslateMidi()
        {
            TimeTranslater t = new TimeTranslater();
            IndexLengthWord[] result = t.TranslateToIndex(new DateTime(2013, 3, 25, 12, 0, 0));
            Assert.AreEqual(t.midi, result[2]);
            Assert.AreEqual(3, result.Length);
        }

        [TestMethod]
        public void TranslateMinuit()
        {
            TimeTranslater t = new TimeTranslater();
            IndexLengthWord[] result = t.TranslateToIndex(new DateTime(2013, 3, 25, 0, 0, 0));
            Assert.AreEqual(t.minuit, result[2]);
            Assert.AreEqual(3, result.Length);
        }

        [TestMethod]
        public void TranslateTroisHeurePour15h()
        {
            TimeTranslater t = new TimeTranslater();
            IndexLengthWord[] result = t.TranslateToIndex(new DateTime(2013, 3, 25, 15, 0, 0));
            Assert.AreEqual(t.trois, result[2]);
            Assert.AreEqual(t.heures, result[3]);
            Assert.AreEqual(4, result.Length);
        }
    }
}
