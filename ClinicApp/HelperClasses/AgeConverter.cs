using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace ClinicApp.XamlPages
{
    public class AgeConverter: IValueConverter
    {
        //age converting method for solving second task
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime birthDate)
            {
                int age;
                age = DateTime.Now.Year - birthDate.Year;
                // if children was born less then 1 year ago
                if (age <=0 || (age == 1 && birthDate.Month > DateTime.Now.Month)) 
                {
                    age = CalculateMonth(birthDate);

                    return age + " (мес.)";
                }

                // adult and children 1 year and more
                if (birthDate.Month > DateTime.Now.Month)
                {
                    age--;
                }
                if (birthDate.Month == DateTime.Now.Month)
                {
                    if (birthDate.Day > DateTime.Now.Day)
                    {
                        age--;
                    }
                }

                return age;
            }
            return Binding.DoNothing;
        }
        private int CalculateMonth(DateTime birthDate)
        {
            int age;
            if (birthDate.Year == DateTime.Now.Year)
            {
                age = DateTime.Now.Month - birthDate.Month - 1;
                if (birthDate.Day <= DateTime.Now.Day)
                {
                    age++;
                }
            }
            else
            {
                age = 12 - birthDate.Month + DateTime.Now.Month - 1;
                if (birthDate.Day <= DateTime.Now.Day)
                {
                    age++;
                }
            }
            return age;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
