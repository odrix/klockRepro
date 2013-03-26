using System;
namespace klockRepro.Business
{
    public interface ITimeTranslater
    {
        Word[] Translate(DateTime time);
    }
}
