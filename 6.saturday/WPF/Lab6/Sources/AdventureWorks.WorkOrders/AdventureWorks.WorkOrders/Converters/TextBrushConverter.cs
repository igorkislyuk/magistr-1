using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace AdventureWorks.WorkOrders.Converters
{
    [ValueConversion(typeof(string), typeof(Brush))]
    public class TextBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (null == values)
            {
                return false;
            }
            SolidColorBrush brush = new SolidColorBrush();
            if ((values[0] is DateTime) &&
                (values[1] is DateTime))
            {
                DateTime scheduledDate = (DateTime) values[0];
                DateTime actualDate = (DateTime) values[1];
                brush.Color = (actualDate > scheduledDate) ? Colors.Red : Colors.Black;
                return brush;
            }
            else
            {
                decimal plannedCost = (decimal) values[0];
                decimal actualCost = (decimal) values[1];
                brush.Color = (actualCost > plannedCost) ? Colors.Red : Colors.Black;
                return brush;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}