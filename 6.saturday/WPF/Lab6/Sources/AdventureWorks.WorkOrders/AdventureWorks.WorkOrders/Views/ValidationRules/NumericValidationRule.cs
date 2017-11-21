using System;
using System.Globalization;
using System.Windows.Controls;

namespace AdventureWorks.WorkOrders.ValidationRules
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intResult;
            double doubleResult;
            if ((true == Int32.TryParse(value.ToString(), out intResult)) ||
                (true == Double.TryParse(value.ToString(), out doubleResult)))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "This value must be a number.");
        }
    }
}
