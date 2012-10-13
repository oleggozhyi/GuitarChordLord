using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuitarChordLord.Mvvm;
using GuitarChords.Core;

namespace GuitarChordLord.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ChordsListViewModel : ViewModelBase, IRefreshable
    {
        private readonly IChordService _chordService;
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the ChordsListBViewModel class.
        /// </summary>
        public ChordsListViewModel(IChordService chordService, INavigationService navigationService)
        {
            _chordService = chordService;
            _navigationService = navigationService;
            GoBackCommand = new RelayCommand(GoBack);
            Root = _chordService.SelectedRoot;
            LoadData();
        }

        private async void LoadData()
        {
            var chords = _chordService.GetChords(Root);
            Chords = chords.Select(c => new ChordsItemViewModel(c));
            RaisePropertyChanged(() => Chords);
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }

        public string PageTitle
        {
            get { return Root.Name + " chords"; }
        }

        private NoteName Root { get; set; }

        public ICommand GoBackCommand { get; private set; }

        public IEnumerable<ChordsItemViewModel> Chords { get; set; }

        public void Refresh()
        {
            Root = _chordService.SelectedRoot;
            LoadData();
        }
    }
}