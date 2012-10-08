using System.Linq;
using GalaSoft.MvvmLight;
using GuitarChords.Core;

namespace GuitarChordLord.ViewModel
{
    public class ChordsItemViewModel : ViewModelBase
    {
        private readonly Chord _chord;

        public ChordsItemViewModel(Chord chord)
        {
            _chord = chord;
        }

        public string Name
        {
            get { return _chord.Name; }
        }


        public string Fingering
        {
            get { return _chord.Fingerings.First().ToString(); }
        }
    }
}