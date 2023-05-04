using System.ComponentModel.DataAnnotations;

namespace ValidationsDemo.Common
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime today = DateTime.Now;
            DateTime inputDate;
            DateTime.TryParse(value?.ToString(), out inputDate);

            if(inputDate <= today)
            {
                return true;
            }

            return false;
        }
    }
}
