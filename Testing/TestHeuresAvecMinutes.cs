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
            TimeTranslaterFR t = new TimeTranslaterFR();
            Word[] result = t.Translate(new DateTime(2013, 3, 25, 2, 5, 0));
            Assert.AreEqual(t.cinqm, result[4], "5 minutes");
            Assert.AreEqual(5, result.Length);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 7, 0));
            Assert.AreEqual(t.cinqm, result[4], "7 minutes");
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TranslateDeuxHeureDix()
        {
            TimeTranslaterFR t = new TimeTranslaterFR();
            Word[] result = t.Translate(new DateTime(2013, 3, 25, 2, 10, 0));
            Assert.AreEqual(t.dixm, result[4], "10 minutes");
            Assert.AreEqual(5, result.Length);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 12, 0));
            Assert.AreEqual(t.dixm, result[4], "12 minutes");
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TranslateDeuxHeureEtQuart()
        {
            TimeTranslaterFR t = new TimeTranslaterFR();
            Word[] result = t.Translate(new DateTime(2013, 3, 25, 2, 15, 0));
            Assert.AreEqual(t.etq, result[4], "'et' 15 minutes");
            Assert.AreEqual(t.quart, result[5], "'quart' 15 minutes");
            Assert.AreEqual(6, result.Length);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 16, 0));
            Assert.AreEqual(t.etq, result[4], "'et' 16 minutes");
            Assert.AreEqual(t.quart, result[5], "'quart' 16 minutes");
            Assert.AreEqual(6, result.Length);
        }

        [TestMethod]
        public void TranslateTroisHeureMoinsCinq()
        {
            TimeTranslaterFR t = new TimeTranslaterFR();
            Word[] result = t.Translate(new DateTime(2013, 3, 25, 2, 55, 0));
            Assert.AreEqual(t.trois, result[2], "'trois' 55 minutes");
            Assert.AreEqual(t.heures, result[3], "'heures' 55 minutes");
            Assert.AreEqual(t.moins, result[4], "'moins' 55 minutes");
            Assert.AreEqual(t.cinqm, result[5], "'cinq' 55 minutes");
            Assert.AreEqual(6, result.Length);
            result = t.Translate(new DateTime(2013, 3, 25, 2, 57, 0));
            Assert.AreEqual(t.trois, result[2], "'trois' 57 minutes");
            Assert.AreEqual(t.heures, result[3], "'heures' 57 minutes");
            Assert.AreEqual(t.moins, result[4], "'moins' 57 minutes");
            Assert.AreEqual(t.cinqm, result[5], "'cinq' 57 minutes");
            Assert.AreEqual(6, result.Length);
        }

        [TestMethod]
        public void Translate3heures()
        {
            TimeTranslaterFR t = new TimeTranslaterFR();
            Word[] result = t.Translate(new DateTime(2013, 3, 25, 3, 0, 0));
            Assert.AreEqual(t.trois, result[2], "'trois' 0 minutes");
            Assert.AreEqual(t.heures, result[3], "'heures' 0 minutes");
            Assert.AreEqual(4, result.Length);
            result = t.Translate(new DateTime(2013, 3, 25, 3, 2, 0));
            Assert.AreEqual(t.trois, result[2], "'trois' 2 minutes");
            Assert.AreEqual(t.heures, result[3], "'heures' 2 minutes");
            Assert.AreEqual(4, result.Length);
        }
    }
}
