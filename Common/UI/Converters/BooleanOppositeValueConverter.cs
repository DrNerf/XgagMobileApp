using System;
using System.Globalization;
using Xamarin.Forms;

namespace Common
{
    public class BooleanOppositeValueConverter : IValueConverter
    {
        private bool InvertBoolean(object value)
        {
            var booleanValue = (bool?)value;
            if (booleanValue.HasValue)
            {
                return !booleanValue.Value;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return InvertBoolean(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return InvertBoolean(value);
        }
    }
}
