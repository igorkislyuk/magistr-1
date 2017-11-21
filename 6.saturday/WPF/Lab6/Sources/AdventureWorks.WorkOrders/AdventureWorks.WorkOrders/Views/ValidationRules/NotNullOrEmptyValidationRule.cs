using System.Globalization;
using System.Windows.Controls;

namespace AdventureWorks.WorkOrders.ValidationRules
{
    public class NotNullOrEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (true == string.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult(false, "This field must have a value.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
