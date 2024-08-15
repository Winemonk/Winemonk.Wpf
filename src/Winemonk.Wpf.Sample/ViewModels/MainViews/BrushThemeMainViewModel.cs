using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Winemonk.Wpf.Sample.ViewModels.MainViews
{
    public partial class BrushThemeMainViewModel:ObservableObject
    {
        [ObservableProperty]
        private Dictionary<string, Brush> _brushes = new Dictionary<string, Brush>();

        public BrushThemeMainViewModel()
        {
            var resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Winemonk.Wpf;component/Themes/Basic/Brush.xaml")
            };
            SortedDictionary<string, Brush> brushes = new SortedDictionary<string, Brush>();
            foreach (DictionaryEntry item in resourceDictionary)
            {
                if (item.Value is Brush brush)
                {
                    brushes.Add(item.Key.ToString(), brush);
                }
            }
            _brushes = new Dictionary<string, Brush>(brushes);
        }
    }
}
