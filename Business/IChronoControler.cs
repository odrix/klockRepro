using System;
using System.Collections.ObjectModel;
namespace klockRepro.Business
{
    interface IChronoControler
    {
        ObservableCollection<DisplayLetter> DurationToDisplay { get; }
        void Pause();
        void Start();
        void Stop(bool andDisplay = false);
        void TryIncrementeSeconde();
    }
}
