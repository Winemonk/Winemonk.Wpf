using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winemonk.Wpf.Sample.ViewModels.MainViews
{
    public partial class ProgressBarThemeMainViewModel : ObservableObject
    {

        [ObservableProperty]
        private double _progress;

        public ProgressBarThemeMainViewModel()
        {
            
        }
    }
}
