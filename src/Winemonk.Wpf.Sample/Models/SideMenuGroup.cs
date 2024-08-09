using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winemonk.Wpf.Sample.Models
{
    public partial class SideMenuGroup : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private List<SideMenuItem> _menuItems = new List<SideMenuItem>();
    }
}
