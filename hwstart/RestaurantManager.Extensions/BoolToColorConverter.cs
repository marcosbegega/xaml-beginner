using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor  { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isExpedited = (bool)value;

            if (isExpedited)
            {
                return this.TrueColor;
            }
            else
            {
                return this.FalseColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool returnValue = false;

            if ((Color)value == TrueColor)
            {
                returnValue = true;
            }

            return returnValue;
        }
    }
}
