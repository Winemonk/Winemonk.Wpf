using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Winemonk.Wpf.Extenstions;

namespace Winemonk.Wpf.Helpers
{
    /// <summary>
    /// 渐变效果帮助类
    /// </summary>
    internal class GradientHelper
    {
        internal static void InitGradientStoryboard(Control control)
        {
            Brush background = (Brush)control.GetValue(Control.BackgroundProperty);
            Brush hoveredBackground = (Brush)control.GetValue(GradientExtensions.HoveredBackgroundProperty);
            Brush pressedBackground = (Brush)control.GetValue(GradientExtensions.PressedBackgroundProperty);
            double hoverGradientSpeed = (double)control.GetValue(GradientExtensions.HoverGradientSpeedProperty);
            double pressGradientSpeed = (double)control.GetValue(GradientExtensions.PressGradientSpeedProperty);
            Storyboard hoverStoryboard = GradientHelper.GetStoryboard(control, hoveredBackground, hoverGradientSpeed);
            Storyboard pressStoryboard = GradientHelper.GetStoryboard(control, pressedBackground, pressGradientSpeed);
            Storyboard recoverHoveredAnimation = GradientHelper.GetStoryboard(control, hoveredBackground, pressGradientSpeed);
            Storyboard recoverStoryboard = GradientHelper.GetStoryboard(control, background, hoverGradientSpeed);
            control.SetValue(GradientExtensions.HoverStoryboardProperty, hoverStoryboard);
            control.SetValue(GradientExtensions.PressStoryboardProperty, pressStoryboard);
            control.SetValue(GradientExtensions.RecoverHoveredStoryboardProperty, recoverHoveredAnimation);
            control.SetValue(GradientExtensions.RecoverStoryboardProperty, recoverStoryboard);

            control.MouseEnter += (s, e) =>
            {
                BeginStoryboard(s, GradientExtensions.HoverStoryboardProperty);
            };
            control.MouseLeave += (s, e) =>
            {
                BeginStoryboard(s, GradientExtensions.RecoverStoryboardProperty);
            };

            control.PreviewMouseDown += (s, e) =>
            {
                BeginStoryboard(s, GradientExtensions.PressStoryboardProperty);
            };

            control.PreviewMouseUp += (s, e) =>
            {
                if (control.IsMouseOver)
                {
                    BeginStoryboard(s, GradientExtensions.RecoverHoveredStoryboardProperty);
                }
            };
        }

        private static void BeginStoryboard(object s, DependencyProperty storyboardProperty)
        {
            Control ctrl = (Control)s;
            bool isGradable = (bool)ctrl.GetValue(GradientExtensions.IsGradableProperty);
            if (isGradable)
            {
                Storyboard storyboard = (Storyboard)ctrl.GetValue(storyboardProperty);
                storyboard?.Begin();
            }
        }

        internal static Storyboard GetStoryboard(Control control, Brush background, double gradientSpeed)
        {
            Storyboard storyboard = new Storyboard();
            if (background is SolidColorBrush solidColorBrush)
            {
                Color backgroundColor = solidColorBrush.Color;
                ColorAnimation animation = new ColorAnimation
                {
                    To = backgroundColor,
                    Duration = TimeSpan.FromSeconds(gradientSpeed),
                };
                storyboard.Children.Add(animation);
                Storyboard.SetTarget(animation, control);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(Control.Background).(SolidColorBrush.Color)"));
            }
            else if (background is GradientBrush gradientBrush)
            {
                for (int i = 0; i < gradientBrush.GradientStops.Count; i++)
                {
                    Color backgroundColor = gradientBrush.GradientStops[i].Color;
                    ColorAnimation animation = new ColorAnimation
                    {
                        To = backgroundColor,
                        Duration = TimeSpan.FromSeconds(gradientSpeed),
                    };
                    storyboard.Children.Add(animation);
                    Storyboard.SetTarget(animation, control);
                    Storyboard.SetTargetProperty(animation, new PropertyPath($"(Control.Background).(GradientBrush.GradientStops)[{i}].(GradientStop.Color)"));
                }
            }

            return storyboard;
        }

        internal static void ChangeStoryboard(Control control, DependencyProperty storyboardProperty, Brush background = null, double? gradientSpeed = null)
        {
            if (background == null && gradientSpeed == null)
            {
                return;
            }
            Storyboard storyboard = (Storyboard)control.GetValue(storyboardProperty);
            if (storyboard == null)
            {
                GradientHelper.InitGradientStoryboard(control);
            }
            storyboard = (Storyboard)control.GetValue(storyboardProperty);
            if (storyboard == null)
            {
                return;
            }
            if (background is SolidColorBrush solidColorBrush)
            {
                ColorAnimation animation = (ColorAnimation)storyboard.Children[0];
                if (background != null)
                {
                    Color backgroundColor = solidColorBrush.Color;
                    animation.To = backgroundColor;
                }
                if (gradientSpeed != null)
                {
                    animation.Duration = TimeSpan.FromSeconds((double)gradientSpeed);
                }
            }
            else if (background is GradientBrush gradientBrush)
            {
                for (int i = 0; i < gradientBrush.GradientStops.Count && i < storyboard.Children.Count; i++)
                {
                    ColorAnimation animation = (ColorAnimation)storyboard.Children[i];
                    if (background != null)
                    {
                        Color backgroundColor = gradientBrush.GradientStops[i].Color;
                        animation.To = backgroundColor;
                    }
                    if (gradientSpeed != null)
                    {
                        animation.Duration = TimeSpan.FromSeconds((double)gradientSpeed);
                    }
                }
            }
        }
    }
}