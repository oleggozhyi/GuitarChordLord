using System.Collections;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GuitarChords.Core;
using Windows.UI.Xaml.Data;
using System.Linq;

namespace GuitarChordLord.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private readonly IChordService _chordService;
        private IEnumerable<ChordsGroupViewModel> _chordsGroups;

        public MainViewModel(IChordService chordService)
        {
            _chordService = chordService;
            ChordsGroups = chordService.NoteNames.Select(n => new ChordsGroupViewModel
            {
                GroupName = GetChordGroupTitle(n),
                Chords = chordService.GetChords(n).Select(c => new ChordsItemViewModel(c))
            });
        }

        public IEnumerable<ChordsGroupViewModel> ChordsGroups
        {
            get { return _chordsGroups; }
            set { _chordsGroups = value; }
        }

        private static string GetChordGroupTitle(NoteName noteName)
        {
            string note = noteName.IsNatural ? noteName.Name : string.Format("{0}({1})", noteName.Name, noteName.AlternativeName);
            return note + " Chords";
        }
    }

    public class ChordsGroupViewModel : ViewModelBase
    {
        public string GroupName { get; set; }
        public IEnumerable<ChordsItemViewModel> Chords { get; set; }

    }

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

    }

}