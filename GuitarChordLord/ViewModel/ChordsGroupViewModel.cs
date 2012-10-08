using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

namespace GuitarChordLord.ViewModel
{
    public class ChordsGroupViewModel : ViewModelBase
    {
        public string GroupName { get; set; }
        public ChordsItemViewModel[] Chords { get; set; }
        public ChordsItemViewModel[] LimitedChordsList
        {
            get { return Chords; }
        }

    }
}