using System;
using System.Globalization;
using System.Windows.Controls;

namespace AdventureWorks.WorkOrders.ValidationRules
{
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime result;
            if ((true == DateTime.TryParse(value.ToString(), out result)))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "This value must be a date.");
        }
    }
}
