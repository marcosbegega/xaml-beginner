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
    public class BoolToColorConverter : DependencyObject, IValueConverter
    {
        public string TrueColor  { get; set; }
        public string FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isExpedited = (bool)value;

            var property = typeof(Colors).GetRuntimeProperty("Transparent");

            try
            {
                if (isExpedited)
                {
                    property = typeof(Colors).GetRuntimeProperty(this.TrueColor);
                }
                else
                {
                    property = typeof(Colors).GetRuntimeProperty(this.FalseColor);
                }

                return property.GetValue(null);
            }
            catch (NullReferenceException)
            {
                property = typeof(Colors).GetRuntimeProperty("Transparent");

                return property.GetValue(null);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool returnValue = false;

            try
            {
                var trueProperty = typeof(Colors).GetRuntimeProperty(this.TrueColor).GetValue(null);
                if ((Color)value == (Color)trueProperty)
                {
                    returnValue = true;
                }
            }
            catch (NullReferenceException)
            { }

            return returnValue;
        }
    }
}
