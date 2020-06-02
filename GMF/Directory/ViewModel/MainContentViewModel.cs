namespace GMF.Directory.ViewModel
{
    class MainContentViewModel : BaseViewModel
    {
        public SpotifyControlModuleViewModel SpotifyControlModuleViewModel { get; set; }


        public MainContentViewModel()
        {
            SpotifyControlModuleViewModel = new SpotifyControlModuleViewModel();
        }

    }
}
