using System.ComponentModel.DataAnnotations;

namespace BookShop.Infrastructure.Extensions
{
    public class StringLenghtExact : ValidationAttribute
    {
        public int Lenght { get; set; }

        public override bool IsValid(object? value)
        {
            string strValue = value as string;

            if (strValue == null)
            {
                return true;
            }

            foreach (var c in strValue)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }

            if (strValue.Length == Lenght)
            {
                return true;
            }

            return false;
        }
    }
}
