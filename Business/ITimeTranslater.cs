using System;
namespace klockRepro.Business
{
    public interface ITimeTranslater
    {
        string ClockLetters { get; }
        Word[] Translate(DateTime time);
    }
}
