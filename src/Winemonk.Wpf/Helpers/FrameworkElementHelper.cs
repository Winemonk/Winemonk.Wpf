using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Winemonk.Wpf.Helpers
{
    public class FrameworkElementHelper
    {
        public static void SetShake(FrameworkElement element)
        {
            Trigger shakeTrigger = new Trigger();
            shakeTrigger.Property = FrameworkElement.IsMouseOverProperty;
            shakeTrigger.Value = true;

            RotateTransform rotateTransform = new RotateTransform();
            element.RenderTransform = rotateTransform;
            element.RenderTransformOrigin = new Point(0.5, 0.5);

            double span = 10;
            double duration = 0.05;
            DoubleAnimation rotationAnimation1 = new DoubleAnimation
            {
                From = 0,
                To = span,
                Duration = TimeSpan.FromSeconds(duration),
            };
            DoubleAnimation rotationAnimation2 = new DoubleAnimation
            {
                BeginTime = TimeSpan.FromSeconds(duration),
                From = span,
                To = -span,
                Duration = TimeSpan.FromSeconds(duration * 2),
            };
            DoubleAnimation rotationAnimation3 = new DoubleAnimation
            {
                BeginTime = TimeSpan.FromSeconds(duration * 3),
                From = -span,
                To = 0,
                Duration = TimeSpan.FromSeconds(duration),
            };
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(rotationAnimation1);
            storyboard.Children.Add(rotationAnimation2);
            storyboard.Children.Add(rotationAnimation3);
            Storyboard.SetTarget(rotationAnimation1, rotateTransform);
            Storyboard.SetTarget(rotationAnimation2, rotateTransform);
            Storyboard.SetTarget(rotationAnimation3, rotateTransform);
            Storyboard.SetTargetProperty(rotationAnimation1, new PropertyPath(RotateTransform.AngleProperty));
            Storyboard.SetTargetProperty(rotationAnimation2, new PropertyPath(RotateTransform.AngleProperty));
            Storyboard.SetTargetProperty(rotationAnimation3, new PropertyPath(RotateTransform.AngleProperty));
            BeginStoryboard shakeStoryboard = new BeginStoryboard();
            shakeStoryboard.Storyboard = storyboard;
            shakeTrigger.EnterActions.Add(shakeStoryboard);
            
            Style style = new Style(element.GetType(), element.Style);
            style.Triggers.Add(shakeTrigger);
            element.Style = style;
        }
    }
}
