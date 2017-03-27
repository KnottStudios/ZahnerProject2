using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Globalization;

namespace validationRules
{
    class IsNumValidationRule2 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);
            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value is not an Integer in range.");
            int intVal;
            bool canConvert = int.TryParse(strValue, out intVal);
            if (!(-10000 <= intVal && intVal <= 10000))
            {
                canConvert = false;
            }
            return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input is not an Integer in range.");
        }
    }
}
