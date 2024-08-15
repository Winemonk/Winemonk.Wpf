using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Winemonk.Wpf.Converters
{
    public class ContrastingBrushConverter : IValueConverter
    {
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
