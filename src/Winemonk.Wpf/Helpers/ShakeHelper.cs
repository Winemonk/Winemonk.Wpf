using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Winemonk.Wpf.Enums;
using Winemonk.Wpf.Extenstions;

namespace Winemonk.Wpf.Helpers
{
    public class ShakeHelper
    {
        public static void SetShake(FrameworkElement element)
        {
            ShakeMode shakeMode = (ShakeMode)element.GetValue(ShakeExtensions.ShakeModeProperty);
            double shakeDuration = (double)element.GetValue(ShakeExtensions.ShakeDurationProperty);
            MultiTrigger shakeTrigger = new MultiTrigger();
            shakeTrigger.Conditions.Add(new Condition(ShakeExtensions.IsShakeableProperty, true));
            shakeTrigger.Conditions.Add(new Condition(UIElement.IsMouseOverProperty, true));
            if (shakeMode == ShakeMode.Rotate)
            {
                double shakeAngle = (double)element.GetValue(ShakeExtensions.ShakeAngleProperty);
                DoubleAnimation rotationAnimation1 = new DoubleAnimation
                {
                    From = 0,
                    To = shakeAngle,
                    Duration = TimeSpan.FromSeconds(shakeDuration),
                };
                DoubleAnimation rotationAnimation2 = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(shakeDuration),
                    From = shakeAngle,
                    To = -shakeAngle,
                    Duration = TimeSpan.FromSeconds(shakeDuration * 2),
                };
                DoubleAnimation rotationAnimation3 = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(shakeDuration * 3),
                    From = -shakeAngle,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(shakeDuration),
                };
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(rotationAnimation1);
                storyboard.Children.Add(rotationAnimation2);
                storyboard.Children.Add(rotationAnimation3);
                RotateTransform rotateTransform = new RotateTransform();
                Storyboard.SetTarget(rotationAnimation1, rotateTransform);
                Storyboard.SetTarget(rotationAnimation2, rotateTransform);
                Storyboard.SetTarget(rotationAnimation3, rotateTransform);
                Storyboard.SetTargetProperty(rotationAnimation1, new PropertyPath(RotateTransform.AngleProperty));
                Storyboard.SetTargetProperty(rotationAnimation2, new PropertyPath(RotateTransform.AngleProperty));
                Storyboard.SetTargetProperty(rotationAnimation3, new PropertyPath(RotateTransform.AngleProperty));
                BeginStoryboard shakeStoryboard = new BeginStoryboard();
                shakeStoryboard.Name = "WMShakeStoryboard";
                shakeStoryboard.Storyboard = storyboard;
                shakeTrigger.EnterActions.Add(shakeStoryboard);
                element.RenderTransform = rotateTransform;
                element.RenderTransformOrigin = new Point(0.5, 0.5);
            }
            else if (shakeMode == ShakeMode.Horizontal)
            {
                double shakeRange = (double)element.GetValue(ShakeExtensions.ShakeRangeProperty);
                DoubleAnimation rotationAnimation1 = new DoubleAnimation
                {
                    From = 0,
                    To = shakeRange,
                    Duration = TimeSpan.FromSeconds(shakeDuration),
                };
                DoubleAnimation rotationAnimation2 = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(shakeDuration),
                    From = shakeRange,
                    To = -shakeRange,
                    Duration = TimeSpan.FromSeconds(shakeDuration * 2),
                };
                DoubleAnimation rotationAnimation3 = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(shakeDuration * 3),
                    From = -shakeRange,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(shakeDuration),
                };
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(rotationAnimation1);
                storyboard.Children.Add(rotationAnimation2);
                storyboard.Children.Add(rotationAnimation3);
                TranslateTransform translateTransform = new TranslateTransform();
                Storyboard.SetTarget(rotationAnimation1, translateTransform);
                Storyboard.SetTarget(rotationAnimation2, translateTransform);
                Storyboard.SetTarget(rotationAnimation3, translateTransform);
                Storyboard.SetTargetProperty(rotationAnimation1, new PropertyPath(TranslateTransform.XProperty));
                Storyboard.SetTargetProperty(rotationAnimation2, new PropertyPath(TranslateTransform.XProperty));
                Storyboard.SetTargetProperty(rotationAnimation3, new PropertyPath(TranslateTransform.XProperty));
                BeginStoryboard shakeStoryboard = new BeginStoryboard();
                shakeStoryboard.Name = "WMShakeStoryboard";
                shakeStoryboard.Storyboard = storyboard;
                shakeTrigger.EnterActions.Add(shakeStoryboard);
                element.RenderTransform = translateTransform;
            }
            else if (shakeMode == ShakeMode.Vertical)
            {
                double shakeRange = (double)element.GetValue(ShakeExtensions.ShakeRangeProperty);
                DoubleAnimation rotationAnimation1 = new DoubleAnimation
                {
                    From = 0,
                    To = shakeRange,
                    Duration = TimeSpan.FromSeconds(shakeDuration),
                };
                DoubleAnimation rotationAnimation2 = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(shakeDuration),
                    From = shakeRange,
                    To = -shakeRange,
                    Duration = TimeSpan.FromSeconds(shakeDuration * 2),
                };
                DoubleAnimation rotationAnimation3 = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(shakeDuration * 3),
                    From = -shakeRange,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(shakeDuration),
                };
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(rotationAnimation1);
                storyboard.Children.Add(rotationAnimation2);
                storyboard.Children.Add(rotationAnimation3);
                TranslateTransform translateTransform = new TranslateTransform();
                Storyboard.SetTarget(rotationAnimation1, translateTransform);
                Storyboard.SetTarget(rotationAnimation2, translateTransform);
                Storyboard.SetTarget(rotationAnimation3, translateTransform);
                Storyboard.SetTargetProperty(rotationAnimation1, new PropertyPath(TranslateTransform.YProperty));
                Storyboard.SetTargetProperty(rotationAnimation2, new PropertyPath(TranslateTransform.YProperty));
                Storyboard.SetTargetProperty(rotationAnimation3, new PropertyPath(TranslateTransform.YProperty));
                BeginStoryboard shakeStoryboard = new BeginStoryboard();
                shakeStoryboard.Name = "WMShakeStoryboard";
                shakeStoryboard.Storyboard = storyboard;
                shakeTrigger.EnterActions.Add(shakeStoryboard);
                element.RenderTransform = translateTransform;
            }
            Style style = new Style(element.GetType(), element.Style);
            TriggerBase? tgr = style.Triggers.FirstOrDefault(t => t.EnterActions.Any(a => a is BeginStoryboard bs && bs.Name == "WMShakeStoryboard"));
            style.Triggers.Remove(tgr);
            style.Triggers.Add(shakeTrigger);
            element.Style = style;
        }
    }
}
