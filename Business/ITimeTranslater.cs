using System;
namespace klockRepro.Business
{
    public interface ITimeTranslater
    {
        string Translate(DateTime time);
        IndexLengthWord[] TranslateToIndex(DateTime time);
    }
}
