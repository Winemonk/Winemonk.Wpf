using System.Windows;
using Winemonk.Wpf.Enums;
using Winemonk.Wpf.Helpers;

namespace Winemonk.Wpf.Extenstions
{
    public class ShakeExtensions
    {
        public static readonly DependencyProperty IsShakeableProperty = DependencyProperty.RegisterAttached("IsShakeable", typeof(bool), typeof(ShakeExtensions), new PropertyMetadata(default(bool), OnIsShakeableChanged));
        public static readonly DependencyProperty ShakeModeProperty = DependencyProperty.RegisterAttached("ShakeMode", typeof(ShakeMode), typeof(ShakeExtensions), new PropertyMetadata(ShakeMode.Rotate, OnShakeModeChanged));
        public static readonly DependencyProperty ShakeDurationProperty = DependencyProperty.RegisterAttached("ShakeDuration", typeof(double), typeof(ShakeExtensions), new PropertyMetadata(0.05, OnShakeDurationChanged));
        public static readonly DependencyProperty ShakeAngleProperty = DependencyProperty.RegisterAttached("ShakeAngle", typeof(double), typeof(ShakeExtensions), new PropertyMetadata(10.0, OnShakeAngleChanged));
        public static readonly DependencyProperty ShakeRangeProperty = DependencyProperty.RegisterAttached("ShakeRange", typeof(double), typeof(ShakeExtensions), new PropertyMetadata(2.5, OnShakeRangeChanged));

        public static double GetShakeDuration(DependencyObject obj)
        {
            return (double)obj.GetValue(ShakeDurationProperty);
        }
        public static void SetShakeDuration(DependencyObject obj, double value)
        {
            obj.SetValue(ShakeDurationProperty, value);
        }
        public static double GetShakeAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(ShakeAngleProperty);
        }
        public static void SetShakeAngle(DependencyObject obj, double value)
        {
            obj.SetValue(ShakeAngleProperty, value);
        }
        public static bool GetIsShakeable(FrameworkElement element)
        {
            return (bool)element.GetValue(IsShakeableProperty);
        }
        public static void SetIsShakeable(FrameworkElement element, bool value)
        {
            element.SetValue(IsShakeableProperty, value);
        }
        public static double GetShakeRange(DependencyObject obj)
        {
            return (double)obj.GetValue(ShakeRangeProperty);
        }
        public static void SetShakeRange(DependencyObject obj, double value)
        {
            obj.SetValue(ShakeRangeProperty, value);
        }
        public static ShakeMode GetShakeMode(DependencyObject obj)
        {
            return (ShakeMode)obj.GetValue(ShakeModeProperty);
        }
        public static void SetShakeMode(DependencyObject obj, ShakeMode value)
        {
            obj.SetValue(ShakeModeProperty, value);
        }

        private static void OnIsShakeableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is bool isShake && isShake)
            {
                element.Loaded += (s, e) =>
                {
                    ShakeHelper.SetShake(element);
                };
            }
        }
        private static void OnShakeDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && element.IsLoaded)
            {
                ShakeHelper.SetShake(element);
            }
        }
        private static void OnShakeAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && element.IsLoaded)
            {
                ShakeHelper.SetShake(element);
            }
        }
        private static void OnShakeRangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && element.IsLoaded)
            {
                ShakeHelper.SetShake(element);
            }
        }
        private static void OnShakeModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && element.IsLoaded)
            {
                ShakeHelper.SetShake(element);
            }
        }
    }
}
