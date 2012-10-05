using GalaSoft.MvvmLight;
using GuitarChords.Core;
using Windows.UI.Xaml.Data;

namespace GuitarChordLord.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private readonly IChordService _chordService;

        public MainViewModel(IChordService chordService)
        {
            _chordService = chordService;

        }
    }
}