using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        public ICommand SelectChordCommand { get; private set; }
        public ICommand SelectChordRootCommand { get; private set; }

        public MainViewModel(IChordService chordService)
        {
            SelectChordCommand = new RelayCommand<ChordsItemViewModel>(SelectChord);
            SelectChordRootCommand = new RelayCommand<ChordsGroupViewModel>(SelectChordRoot);
            _chordService = chordService;
            LoadChords();

        }
            
        private void SelectChordRoot(ChordsGroupViewModel clickedRoot)
        {
        }

        private void SelectChord(ChordsItemViewModel clickedChord)
        {
            
        }

        private async void LoadChords()
        {
            var chordsGroups = new List<ChordsGroupViewModel>();
            foreach (var n in _chordService.NoteNames)
            {
                var chords = (await _chordService.GetChordsAsync(n)).Select(c => new ChordsItemViewModel(c)).ToArray();
                chordsGroups.Add(new ChordsGroupViewModel { Root = n, Chords = chords });
            }

            ChordsGroups = chordsGroups;
        }
    }
}