using System.Windows;
using System.Windows.Media;

namespace Winemonk.Wpf
{
    public class ButtonExtensions
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonExtensions), new PropertyMetadata(new CornerRadius(3)));

        public static void SetCornerRadius(UIElement element, CornerRadius value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }

        public static CornerRadius GetCornerRadius(UIElement element)
        {
            return (CornerRadius)element.GetValue(CornerRadiusProperty);
        }
        

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(ButtonExtensions), new PropertyMetadata(Brushes.LightGray));

        public static void SetHoverBackground(UIElement element, Brush value)
        {
            element.SetValue(HoverBackgroundProperty, value);
        }

        public static Brush GetHoverBackground(UIElement element)
        {
            return (Brush)element.GetValue(HoverBackgroundProperty);
        }

        public static readonly DependencyProperty PressBackgroundProperty =
            DependencyProperty.RegisterAttached("PressBackground", typeof(Brush), typeof(ButtonExtensions), new PropertyMetadata(Brushes.Gray));

        public static void SetPressBackground(UIElement element, Brush value)
        {
            element.SetValue(PressBackgroundProperty, value);
        }

        public static Brush GetPressBackground(UIElement element)
        {
            return (Brush)element.GetValue(PressBackgroundProperty);
        }


        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(ButtonExtensions), new PropertyMetadata(Brushes.Transparent));

        public static void SetHoverForeground(UIElement element, Brush value)
        {
            element.SetValue(HoverForegroundProperty, value);
        }

        public static Brush GetHoverForeground(UIElement element)
        {
            return (Brush)element.GetValue(HoverForegroundProperty);
        }

        public static readonly DependencyProperty PressForegroundProperty =
            DependencyProperty.RegisterAttached("PressForeground", typeof(Brush), typeof(ButtonExtensions), new PropertyMetadata(Brushes.Transparent));

        public static void SetPressForeground(UIElement element, Brush value)
        {
            element.SetValue(PressForegroundProperty, value);
        }

        public static Brush GetPressForeground(UIElement element)
        {
            return (Brush)element.GetValue(PressForegroundProperty);
        }
    }
}
