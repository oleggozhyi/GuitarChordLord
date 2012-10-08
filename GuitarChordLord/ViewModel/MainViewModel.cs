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

        public IEnumerable<ChordsGroupViewModel> ChordsGroups
        {
            get { return _chordsGroups; }
            private set
            {
                if(_chordsGroups != value)
                {
                    _chordsGroups = value;
                    RaisePropertyChanged(() => ChordsGroups);
                }
            }
        }

        public MainViewModel(IChordService chordService)
        {
            _chordService = chordService;
            LoadChords();

        }

        private async void LoadChords()
        {
            var chordsGroups = new List<ChordsGroupViewModel>();
            foreach (var n in _chordService.NoteNames)
            {
                var chords = (await _chordService.GetChordsAsync(n)).Select(c => new ChordsItemViewModel(c)).ToArray();
                chordsGroups.Add(new ChordsGroupViewModel { GroupName = GetChordGroupTitle(n), Chords = chords });
            }

            ChordsGroups = chordsGroups;
        }


        private static string GetChordGroupTitle(NoteName noteName)
        {
            string note = noteName.IsNatural ? noteName.Name : string.Format("{0}({1})", noteName.Name, noteName.AlternativeName);
            return note + " Chords";
        }
    }
}