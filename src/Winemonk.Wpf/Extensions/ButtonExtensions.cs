using System.Windows;

namespace Winemonk.Wpf.Extenstions
{
    /// <summary>
    /// 按钮扩展类
    /// </summary>
    public class ButtonExtensions
    {
        /// <summary>
        /// 按钮圆角属性
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonExtensions), new PropertyMetadata(new CornerRadius(3)));

        /// <summary>
        /// 设置按钮圆角属性
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetCornerRadius(UIElement element, CornerRadius value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// 获取按钮圆角属性
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static CornerRadius GetCornerRadius(UIElement element)
        {
            return (CornerRadius)element.GetValue(CornerRadiusProperty);
        }
    }
}