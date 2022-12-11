using MessagePack.Formatters;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Extensions
{
    public class StringLenghtExact : ValidationAttribute
    {
        public int Lenght { get; set; }

        public override bool IsValid(object? value)
        {
            string strValue = value as string;

            foreach (var c in strValue)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }

            if (strValue == null || strValue.Length == Lenght)
            {
                return true;
            }

            return false;
        }
    }
}
