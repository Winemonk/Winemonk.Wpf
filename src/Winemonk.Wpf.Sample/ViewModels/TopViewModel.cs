using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Regions;

namespace Winemonk.Wpf.Sample.ViewModels
{
    public partial class TopViewModel : ObservableObject
    {
        private IRegionManager _regionManager;
        public TopViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        [RelayCommand]
        private void GoBack()
        {
            _regionManager.Regions["MainRegion"].NavigationService.Journal.GoBack();
        }

        [RelayCommand]
        private void GoForward()
        {
            _regionManager.Regions["MainRegion"].NavigationService.Journal.GoForward();
        }
    }
}
