using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuitarChordLord.Mvvm;
using GuitarChords.Core;
using Windows.UI.Xaml.Data;
using System.Linq;

namespace GuitarChordLord.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IChordService _chordService;
        private readonly INavigationService _navigationService;
        private ObservableCollection<ChordsGroupViewModel> _chordsGroups;
        private List<ChordsGroupViewModel> _allChordsGroups;
        private bool _showNaturalOnly;

        public ObservableCollection<ChordsGroupViewModel> ChordsGroups
        {
            get { return _chordsGroups; }
            set { Set(() => ChordsGroups, ref _chordsGroups, value); }

        }

        public bool ShowNaturalOnly
        {
            get { return _showNaturalOnly; }
            set
            {
                if (value != _showNaturalOnly)
                {
                    Set(() => ShowNaturalOnly, ref _showNaturalOnly, value);

                    UpdateChordsGroups();
                }
            }
        }

        public ICommand SelectChordCommand { get; private set; }

        public ICommand SelectChordRootCommand { get; private set; }

        public MainViewModel(IChordService chordService, INavigationService navigationService)
        {
            SelectChordCommand = new RelayCommand<ChordsItemViewModel>(SelectChord);
            SelectChordRootCommand = new RelayCommand<ChordsGroupViewModel>(SelectChordRoot);
            _chordService = chordService;
            _navigationService = navigationService;
            LoadChords();

        }

        private void UpdateChordsGroups()
        {
            if (ShowNaturalOnly)
            {
                foreach (var cg in _allChordsGroups.Where(g => !g.Root.IsNatural))
                    ChordsGroups.Remove(cg);
                return;
            }
            foreach (var cg in _allChordsGroups)
            {
                if(!ChordsGroups.Contains(cg))
                {
                    ChordsGroups.Insert(_allChordsGroups.IndexOf(cg), cg);
                }
            }
        }

        private void SelectChordRoot(ChordsGroupViewModel clickedRoot)
        {
            _chordService.SelectedRoot = clickedRoot.Root;
            _navigationService.Navigate(typeof(ChordsList));
        }

        private void SelectChord(ChordsItemViewModel clickedChord)
        {

        }

        private void LoadChords()
        {
            var chordsGroups = new List<ChordsGroupViewModel>();
            foreach (var n in _chordService.NoteNames)
            {
                var chords = _chordService.GetChords(n).Select(c => new ChordsItemViewModel(c)).ToArray();
                chordsGroups.Add(new ChordsGroupViewModel { Root = n, Chords = chords });
            }
            _allChordsGroups = chordsGroups;
            ChordsGroups = new ObservableCollection<ChordsGroupViewModel>(chordsGroups);

        }
    }
}