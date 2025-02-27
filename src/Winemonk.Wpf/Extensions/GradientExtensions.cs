using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Winemonk.Wpf.Helpers;

namespace Winemonk.Wpf.Extenstions
{
    /// <summary>
    /// 渐变效果扩展类
    /// </summary>
    public class GradientExtensions
    {
        /// <summary>
        /// 悬停时背景颜色
        /// </summary>
        public static readonly DependencyProperty HoveredBackgroundProperty = DependencyProperty.RegisterAttached("HoveredBackground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.LightGray, OnHoveredBackgroundChanged));

        /// <summary>
        /// 悬停时前景颜色
        /// </summary>
        public static readonly DependencyProperty HoveredForegroundProperty = DependencyProperty.RegisterAttached("HoveredForeground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.DarkBlue));

        /// <summary>
        /// 悬停时渐变效果的速度
        /// </summary>
        public static readonly DependencyProperty HoverGradientSpeedProperty = DependencyProperty.RegisterAttached("HoverGradientSpeed", typeof(double), typeof(GradientExtensions), new PropertyMetadata(0.2, OnHoverGradientSpeedChanged));

        /// <summary>
        /// 是否可以进行渐变效果
        /// </summary>
        public static readonly DependencyProperty IsGradableProperty = DependencyProperty.RegisterAttached("IsGradable", typeof(bool), typeof(GradientExtensions), new PropertyMetadata(false, OnIsGradableChanged));

        /// <summary>
        /// 按下时背景颜色
        /// </summary>
        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.Gray, OnPressedBackgroundChanged));

        /// <summary>
        /// 按下时前景颜色
        /// </summary>
        public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.RegisterAttached("PressedForeground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.DarkSlateBlue));

        /// <summary>
        /// 按下时渐变效果的速度
        /// </summary>
        public static readonly DependencyProperty PressGradientSpeedProperty = DependencyProperty.RegisterAttached("PressGradientSpeed", typeof(double), typeof(GradientExtensions), new PropertyMetadata(0.1, OnPressGradientSpeedChanged));

        internal static readonly DependencyProperty HoverStoryboardProperty = DependencyProperty.RegisterAttached("HoverStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));

        internal static readonly DependencyProperty PressStoryboardProperty = DependencyProperty.RegisterAttached("PressStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));

        internal static readonly DependencyProperty RecoverHoveredStoryboardProperty = DependencyProperty.RegisterAttached("RecoverHoveredStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));

        internal static readonly DependencyProperty RecoverStoryboardProperty = DependencyProperty.RegisterAttached("RecoverStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));

        /// <summary>
        /// 获取悬停时背景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Brush GetHoveredBackground(Control control)
        {
            return (Brush)control.GetValue(HoveredBackgroundProperty);
        }

        /// <summary>
        /// 获取悬停时前景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Brush GetHoveredForeground(Control control)
        {
            return (Brush)control.GetValue(HoveredForegroundProperty);
        }

        /// <summary>
        /// 获取按下时渐变效果的速度
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetHoverGradientSpeed(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverGradientSpeedProperty);
        }

        /// <summary>
        /// 获取是否可以进行渐变效果
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetIsGradable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsGradableProperty);
        }

        /// <summary>
        /// 获取按下时背景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Brush GetPressedBackground(Control control)
        {
            return (Brush)control.GetValue(PressedBackgroundProperty);
        }

        /// <summary>
        /// 获取按下时前景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Brush GetPressedForeground(Control control)
        {
            return (Brush)control.GetValue(PressedForegroundProperty);
        }

        /// <summary>
        /// 获取悬停时渐变效果的速度
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetPressGradientSpeed(DependencyObject obj)
        {
            return (double)obj.GetValue(PressGradientSpeedProperty);
        }

        /// <summary>
        /// 设置悬停时背景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetHoveredBackground(Control control, Brush value)
        {
            control.SetValue(HoveredBackgroundProperty, value);
        }

        /// <summary>
        /// 设置悬停时前景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetHoveredForeground(Control control, Brush value)
        {
            control.SetValue(HoveredForegroundProperty, value);
        }

        /// <summary>
        /// 设置按下时渐变效果的速度
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetHoverGradientSpeed(DependencyObject obj, double value)
        {
            obj.SetValue(HoverGradientSpeedProperty, value);
        }

        /// <summary>
        /// 设置是否可以进行渐变效果
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetIsGradable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsGradableProperty, value);
        }

        /// <summary>
        /// 设置按下时背景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetPressedBackground(Control control, Brush value)
        {
            control.SetValue(PressedBackgroundProperty, value);
        }

        /// <summary>
        /// 设置按下时前景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetPressedForeground(Control control, Brush value)
        {
            control.SetValue(PressedForegroundProperty, value);
        }

        /// <summary>
        /// 设置悬停时渐变效果的速度
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetPressGradientSpeed(DependencyObject obj, double value)
        {
            obj.SetValue(PressGradientSpeedProperty, value);
        }

        internal static Storyboard GetHoverStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(HoverStoryboardProperty);
        }

        internal static Storyboard GetPressStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(PressStoryboardProperty);
        }

        internal static Storyboard GetRecoverHoveredStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(RecoverHoveredStoryboardProperty);
        }

        internal static Storyboard GetRecoverStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(RecoverStoryboardProperty);
        }

        internal static void SetHoverStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(HoverStoryboardProperty, value);
        }

        internal static void SetPressStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(PressStoryboardProperty, value);
        }

        internal static void SetRecoverHoveredStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(RecoverHoveredStoryboardProperty, value);
        }

        internal static void SetRecoverStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(RecoverStoryboardProperty, value);
        }

        private static void OnHoveredBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control ctrl = (Control)d;
            if (ctrl.IsLoaded)
            {
                Brush newBrush = (Brush)e.NewValue;
                GradientHelper.ChangeStoryboard(ctrl, HoverStoryboardProperty, newBrush);
                GradientHelper.ChangeStoryboard(ctrl, RecoverHoveredStoryboardProperty, newBrush);
            }
        }

        private static void OnHoverGradientSpeedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control ctrl = (Control)d;
            if (ctrl.IsLoaded)
            {
                double newSpeed = (double)e.NewValue;
                GradientHelper.ChangeStoryboard(ctrl, HoverStoryboardProperty, null, newSpeed);
                GradientHelper.ChangeStoryboard(ctrl, RecoverStoryboardProperty, null, newSpeed);
            }
        }

        private static void OnIsGradableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Control control)
            {
                control.Loaded += (sender, args) =>
                {
                    GradientHelper.InitGradientStoryboard((Control)sender);
                };
            }
        }

        private static void OnPressedBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control ctrl = (Control)d;
            if (ctrl.IsLoaded)
            {
                Brush newBrush = (Brush)e.NewValue;
                GradientHelper.ChangeStoryboard(ctrl, PressStoryboardProperty, newBrush);
            }
        }

        private static void OnPressGradientSpeedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control ctrl = (Control)d;
            if (ctrl.IsLoaded)
            {
                double newSpeed = (double)e.NewValue;
                GradientHelper.ChangeStoryboard(ctrl, PressStoryboardProperty, null, newSpeed);
                GradientHelper.ChangeStoryboard(ctrl, RecoverHoveredStoryboardProperty, null, newSpeed);
            }
        }
    }
}