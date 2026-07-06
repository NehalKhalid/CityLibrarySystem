using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Extensions
{
    public static class StringExtensions
    {
        public static string Normalize(this string str) => str?.Trim().ToUpperInvariant() ?? string.Empty;
        public static bool IsValidEmail(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            bool hasAt = false;
            bool hasDot = false;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '@') hasAt = true;
                if (value[i] == '.') hasDot = true;
            }

            return hasAt && hasDot;
        }
        public static bool IsValidPhone(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                    return true;
            }
            return false;
        }
    }
}
