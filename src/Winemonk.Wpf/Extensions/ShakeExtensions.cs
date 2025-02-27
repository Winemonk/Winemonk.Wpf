using System.Windows;
using Winemonk.Wpf.Enums;
using Winemonk.Wpf.Helpers;

namespace Winemonk.Wpf.Extenstions
{
    /// <summary>
    /// 抖动效果扩展类
    /// </summary>
    public class ShakeExtensions
    {
        /// <summary>
        /// 是否开启抖动效果
        /// </summary>
        public static readonly DependencyProperty IsShakeableProperty = DependencyProperty.RegisterAttached("IsShakeable", typeof(bool), typeof(ShakeExtensions), new PropertyMetadata(default(bool), OnIsShakeableChanged));

        /// <summary>
        /// 抖动模式
        /// </summary>
        public static readonly DependencyProperty ShakeModeProperty = DependencyProperty.RegisterAttached("ShakeMode", typeof(ShakeMode), typeof(ShakeExtensions), new PropertyMetadata(ShakeMode.Rotate, OnShakeModeChanged));

        /// <summary>
        /// 抖动持续时间
        /// </summary>
        public static readonly DependencyProperty ShakeDurationProperty = DependencyProperty.RegisterAttached("ShakeDuration", typeof(double), typeof(ShakeExtensions), new PropertyMetadata(0.05, OnShakeDurationChanged));

        /// <summary>
        /// 抖动角度
        /// </summary>
        public static readonly DependencyProperty ShakeAngleProperty = DependencyProperty.RegisterAttached("ShakeAngle", typeof(double), typeof(ShakeExtensions), new PropertyMetadata(10.0, OnShakeAngleChanged));

        /// <summary>
        /// 抖动范围
        /// </summary>
        public static readonly DependencyProperty ShakeRangeProperty = DependencyProperty.RegisterAttached("ShakeRange", typeof(double), typeof(ShakeExtensions), new PropertyMetadata(2.5, OnShakeRangeChanged));

        /// <summary>
        /// 获取抖动持续时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetShakeDuration(DependencyObject obj)
        {
            return (double)obj.GetValue(ShakeDurationProperty);
        }

        /// <summary>
        /// 设置抖动持续时间
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetShakeDuration(DependencyObject obj, double value)
        {
            obj.SetValue(ShakeDurationProperty, value);
        }

        /// <summary>
        /// 获取抖动角度
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetShakeAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(ShakeAngleProperty);
        }

        /// <summary>
        /// 设置抖动角度
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetShakeAngle(DependencyObject obj, double value)
        {
            obj.SetValue(ShakeAngleProperty, value);
        }

        /// <summary>
        /// 获取抖动范围
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetIsShakeable(FrameworkElement element)
        {
            return (bool)element.GetValue(IsShakeableProperty);
        }

        /// <summary>
        /// 设置抖动范围
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetIsShakeable(FrameworkElement element, bool value)
        {
            element.SetValue(IsShakeableProperty, value);
        }

        /// <summary>
        /// 获取抖动模式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetShakeRange(DependencyObject obj)
        {
            return (double)obj.GetValue(ShakeRangeProperty);
        }

        /// <summary>
        /// 设置抖动模式
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetShakeRange(DependencyObject obj, double value)
        {
            obj.SetValue(ShakeRangeProperty, value);
        }

        /// <summary>
        /// 获取抖动模式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ShakeMode GetShakeMode(DependencyObject obj)
        {
            return (ShakeMode)obj.GetValue(ShakeModeProperty);
        }

        /// <summary>
        /// 设置抖动模式
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetShakeMode(DependencyObject obj, ShakeMode value)
        {
            obj.SetValue(ShakeModeProperty, value);
        }

        private static void OnIsShakeableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is bool isShake && isShake)
            {
                element.Loaded += (s, e1) =>
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