
namespace GMF.Directory.ViewModel
{
    class SpotifyControlModuleViewModel : BaseViewModel
    {
        public SpotifyControlModuleLoginViewModel SpotifyControlModuleLoginViewModel { get; set; }
        public SpotifyControlModuleViewModel()
        {
            SpotifyControlModuleLoginViewModel = new SpotifyControlModuleLoginViewModel();
        }
    }
}
