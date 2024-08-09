using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Regions;
using Winemonk.Wpf.Sample.Models;

namespace Winemonk.Wpf.Sample.ViewModels
{
    public partial class SideViewModel : ObservableObject
    {
        private readonly IRegionManager _regionManager;

        [ObservableProperty]
        private List<SideMenuGroup> _menuGroups = new List<SideMenuGroup>
        {
            new SideMenuGroup
            {
                Name = "样式",
                MenuItems = new List<SideMenuItem>
                {
                    new SideMenuItem { Name = "Brush", View = "BrushThemeMainView" },
                    new SideMenuItem { Name = "Button", View = "ButtonThemeMainView" },
                    new SideMenuItem { Name = "ProgressBar", View = "ProgressBarThemeMainView" },
                }
            },
            new SideMenuGroup
            {
                Name = "控件",
                MenuItems = new List<SideMenuItem>
                {
                    new SideMenuItem { Name = "DataGrid", View = "DataGridControlMainView" },
                }
            }
        };

        public SideViewModel(IRegionManager regionManager)
        {

            _regionManager = regionManager;
        }

        [RelayCommand]
        private void SideMenu(SideMenuItem item)
        {
            _regionManager.RequestNavigate("MainRegion", item.View);
        }
    }
}
