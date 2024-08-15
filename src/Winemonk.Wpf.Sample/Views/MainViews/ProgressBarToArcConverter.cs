using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Winemonk.Wpf.Sample.Views.MainViews
{
    public class ProgressBarToArcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3)
                return null;

            double value = System.Convert.ToDouble(values[0]);
            double maximum = System.Convert.ToDouble(values[1]);
            double size = System.Convert.ToDouble(values[2]);

            // 计算有效半径，并考虑StrokeThickness
            double radius = Math.Max(0, (size - 10) / 2);
            Point center = new Point(radius + 5, radius + 5); // 考虑StrokeThickness偏移

            // 计算当前角度（进度百分比）
            double angle = 360 * (value / maximum);

            // 圆的起点位于顶部
            Point startPoint = new Point(center.X, center.Y - radius);

            // 计算圆弧的终点
            double endX = center.X +  radius * Math.Sin(Math.PI * angle / 180);
            double endY = center.Y - radius * Math.Cos(Math.PI * angle / 180);
            Point endPoint = new Point(endX, endY);

            // 判断是否为大角度弧
            bool isLargeArc = angle > 180.0;

            // 构建圆弧路径
            PathFigure figure = new PathFigure
            {
                StartPoint = startPoint,
                IsClosed = false,
                IsFilled = false // 这行可以根据需要选择是否填充
            };

            // 如果角度大于0，添加ArcSegment
            if (angle > 0)
            {
                figure.Segments.Add(new ArcSegment
                {
                    Point = endPoint,
                    Size = new Size(radius, radius),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc
                });
            }

            PathGeometry geometry = new PathGeometry();
            geometry.Figures.Add(figure);

            return geometry;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
