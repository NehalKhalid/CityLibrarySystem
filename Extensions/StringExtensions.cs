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
    }
}
