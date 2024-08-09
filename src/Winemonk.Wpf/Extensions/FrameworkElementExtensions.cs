using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Winemonk.Wpf.Helpers;

namespace Winemonk.Wpf
{
    public class FrameworkElementExtensions
    {
        public static readonly DependencyProperty IsShakeProperty =
            DependencyProperty.RegisterAttached(
                "IsShake",
                typeof(bool),   
                typeof(FrameworkElementExtensions),
                new PropertyMetadata(default(bool), OnIsShakeChanged));

        private static void OnIsShakeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is bool isShake && isShake)
            {
                element.Loaded += (s, e) =>
                {
                    FrameworkElementHelper.SetShake(element);
                };
            }
        }

        public static void SetIsShake(FrameworkElement element, bool value)
        {
            element.SetValue(IsShakeProperty, value);
        }

        public static bool GetIsShake(FrameworkElement element)
        {
            return (bool)element.GetValue(IsShakeProperty);
        }
    }
}
