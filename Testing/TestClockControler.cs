using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using klockRepro.Business;

namespace Testing
{
    [TestClass]
    public class TestClockControler
    {
        private class MidiEtQuartTranslate : ITimeTranslater
        {
            public Word[] Translate(DateTime time)
            {
                List<Word> result = new List<Word>();
                result.Add(new Word() { Index = 0, Length = 2 });    // il
                result.Add(new Word() { Index = 3, Length = 3 });    // est
                result.Add(new Word() { Index = 44, Length = 4 });   //midi
                return result.ToArray();
            }
        }


        [TestMethod]
        public void CurrentTimeToDisplayForMidiEtQuart()
        {
            ClockControler cc = new ClockControler(new MidiEtQuartTranslate());
            cc.CurrentTimeToDisplay();
            Assert.IsTrue(cc.ClockLetters[0].Active, "I");
            Assert.IsTrue(cc.ClockLetters[1].Active, "L");
            Assert.IsFalse(cc.ClockLetters[2].Active, "N");
            Assert.IsTrue(cc.ClockLetters[3].Active, "E");
            Assert.IsTrue(cc.ClockLetters[4].Active, "S");
            Assert.IsTrue(cc.ClockLetters[5].Active, "T");
            Assert.IsFalse(cc.ClockLetters[6].Active, "O");
            Assert.IsFalse(cc.ClockLetters[43].Active, "Q");
            Assert.IsTrue(cc.ClockLetters[44].Active, "M");
            Assert.IsTrue(cc.ClockLetters[45].Active, "I-");
            Assert.IsTrue(cc.ClockLetters[46].Active, "D");
            Assert.IsTrue(cc.ClockLetters[47].Active, "I--");
            Assert.IsFalse(cc.ClockLetters[48].Active, "X");
        }
    }
}
