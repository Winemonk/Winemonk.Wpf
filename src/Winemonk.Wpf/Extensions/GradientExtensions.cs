using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Winemonk.Wpf.Helpers;

namespace Winemonk.Wpf.Extenstions
{
    public class GradientExtensions
    {
        public static readonly DependencyProperty IsGradableProperty = DependencyProperty.RegisterAttached("IsGradable", typeof(bool), typeof(GradientExtensions), new PropertyMetadata(false, OnIsGradableChanged));
        public static readonly DependencyProperty PressGradientSpeedProperty = DependencyProperty.RegisterAttached("PressGradientSpeed", typeof(double), typeof(GradientExtensions), new PropertyMetadata(0.1, OnPressGradientSpeedChanged));
        public static readonly DependencyProperty HoverGradientSpeedProperty = DependencyProperty.RegisterAttached("HoverGradientSpeed", typeof(double), typeof(GradientExtensions), new PropertyMetadata(0.2, OnHoverGradientSpeedChanged));
        public static readonly DependencyProperty HoveredBackgroundProperty = DependencyProperty.RegisterAttached("HoveredBackground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.LightGray, OnHoveredBackgroundChanged));
        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.Gray, OnPressedBackgroundChanged));
        public static readonly DependencyProperty HoveredForegroundProperty = DependencyProperty.RegisterAttached("HoveredForeground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.DarkBlue));
        public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.RegisterAttached("PressedForeground", typeof(Brush), typeof(GradientExtensions), new PropertyMetadata(Brushes.DarkSlateBlue));

        public static bool GetIsGradable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsGradableProperty);
        }
        public static void SetIsGradable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsGradableProperty, value);
        }
        public static double GetHoverGradientSpeed(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverGradientSpeedProperty);
        }
        public static void SetHoverGradientSpeed(DependencyObject obj, double value)
        {
            obj.SetValue(HoverGradientSpeedProperty, value);
        }
        public static double GetPressGradientSpeed(DependencyObject obj)
        {
            return (double)obj.GetValue(PressGradientSpeedProperty);
        }
        public static void SetPressGradientSpeed(DependencyObject obj, double value)
        {
            obj.SetValue(PressGradientSpeedProperty, value);
        }
        public static Brush GetHoveredBackground(Control control)
        {
            return (Brush)control.GetValue(HoveredBackgroundProperty);
        }
        public static void SetHoveredBackground(Control control, Brush value)
        {
            control.SetValue(HoveredBackgroundProperty, value);
        }
        public static Brush GetPressedBackground(Control control)
        {
            return (Brush)control.GetValue(PressedBackgroundProperty);
        }
        public static void SetPressedBackground(Control control, Brush value)
        {
            control.SetValue(PressedBackgroundProperty, value);
        }
        public static Brush GetHoveredForeground(Control control)
        {
            return (Brush)control.GetValue(HoveredForegroundProperty);
        }
        public static void SetHoveredForeground(Control control, Brush value)
        {
            control.SetValue(HoveredForegroundProperty, value);
        }
        public static Brush GetPressedForeground(Control control)
        {
            return (Brush)control.GetValue(PressedForegroundProperty);
        }
        public static void SetPressedForeground(Control control, Brush value)
        {
            control.SetValue(PressedForegroundProperty, value);
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
        private static void OnPressedBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control ctrl = (Control)d;
            if (ctrl.IsLoaded)
            {
                Brush newBrush = (Brush)e.NewValue;
                GradientHelper.ChangeStoryboard(ctrl, PressStoryboardProperty, newBrush);
            }
        }



        internal static readonly DependencyProperty HoverStoryboardProperty = DependencyProperty.RegisterAttached("HoverStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));
        internal static readonly DependencyProperty PressStoryboardProperty = DependencyProperty.RegisterAttached("PressStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));
        internal static readonly DependencyProperty RecoverHoveredStoryboardProperty = DependencyProperty.RegisterAttached("RecoverHoveredStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));
        internal static readonly DependencyProperty RecoverStoryboardProperty = DependencyProperty.RegisterAttached("RecoverStoryboard", typeof(Storyboard), typeof(GradientExtensions), new PropertyMetadata(null));

        internal static Storyboard GetHoverStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(HoverStoryboardProperty);
        }
        internal static void SetHoverStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(HoverStoryboardProperty, value);
        }
        internal static Storyboard GetPressStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(PressStoryboardProperty);
        }
        internal static void SetPressStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(PressStoryboardProperty, value);
        }
        internal static Storyboard GetRecoverHoveredStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(RecoverHoveredStoryboardProperty);
        }
        internal static void SetRecoverHoveredStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(RecoverHoveredStoryboardProperty, value);
        }
        internal static Storyboard GetRecoverStoryboard(DependencyObject obj)
        {
            return (Storyboard)obj.GetValue(RecoverStoryboardProperty);
        }
        internal static void SetRecoverStoryboard(DependencyObject obj, Storyboard value)
        {
            obj.SetValue(RecoverStoryboardProperty, value);
        }

    }
}
