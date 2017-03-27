using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Globalization;
using System.Windows.Data;
using ZahnerProject;

namespace validationRules
{
    class IsNumValidationRule2 : ValidationRule
    {
        private int _minValue;
        private int _maxValue;
        private string _errorMessage;
        public int MinimumValue {
            get { return _minValue; }
            set { _minValue = value; }    
        }
        public int MaximumValue {
            get { return _maxValue ; }
            set { _maxValue = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);
            int intVal;
            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Integer");
            bool canConvert = int.TryParse(strValue, out intVal);
            if (canConvert == false) {
                _errorMessage = "Integer";
            }
            if(!(_minValue <= intVal))
            {
                canConvert = false;
                _errorMessage = String.Format("<{0}!",_minValue);
            }
            if (!(intVal <= _maxValue))
            {
                canConvert = false;
                _errorMessage = String.Format(">{0}!", _maxValue);
            }
            return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, _errorMessage);
        }
    }
    class ValidateXandY : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bg = (BindingGroup)value;
            ZahnerXandY xy = (ZahnerXandY)bg.Items[0];

            object objValue = null;
            if (!bg.TryGetValue(xy, "NumX", out objValue)) {
                return new ValidationResult(false, "NumX is null.");
            }
            int NumX;
            if(!Int32.TryParse(objValue as string, out NumX))
                return new ValidationResult(false, "NumX isn't a whole number.");
            if (!bg.TryGetValue(xy, "NumY", out objValue))
            {
                return new ValidationResult(false, "NumY is null.");
            }
            int NumY;
            if (!Int32.TryParse(objValue as string, out NumY))
                return new ValidationResult(false, "NumY isn't a whole number.");
            if (NumX >= NumY + 20 || NumX <= NumY - 20)
            {
                return new ValidationResult(true, "");
            }
            else
            {
                return new ValidationResult(false, "not 20 apart.");
            }

            /*

            int numX = int.Parse(tbNumX.ToString());
            int numY = int.Parse(tbNumY.ToString());

            */
        }
    }
}
