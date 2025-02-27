using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Winemonk.Wpf.Converters
{
    /// <summary>
    /// 对比色的转换器
    /// </summary>
    public class ContrastingBrushConverter : IValueConverter
    {
        /// <summary>
        /// 亮度较高，返回黑色，亮度较低则返回白色
        /// </summary>
        /// <param name="value"><see cref="SolidColorBrush"/></param>
        /// <param name="targetType"><see cref="SolidColorBrush"/></param>
        /// <param name="parameter">参数</param>
        /// <param name="culture"><see cref="CultureInfo"/></param>
        /// <returns><see cref="SolidColorBrush"/></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush solidColorBrush)
            {
                Color originalColor = solidColorBrush.Color;

                // 计算亮度（使用加权公式）
                double brightness = originalColor.R * 0.299 + originalColor.G * 0.587 + originalColor.B * 0.114;

                // 如果亮度较高，则返回黑色，亮度较低则返回白色
                Color contrastingColor = brightness > 128 ? Colors.Black : Colors.White;

                return new SolidColorBrush(contrastingColor);
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        /// <summary>
        /// 不支持转换回原色
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}