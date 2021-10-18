using System;
using System.Collections.Generic;

namespace MdcBlazor.Code
{
    internal static class Common
    {
        internal static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

        // Source https://stackoverflow.com/a/972323
        internal static IReadOnlyList<T> GetEnumListValues<T>() { return (T[])Enum.GetValues(typeof(T)); }

        internal static string GenerateIconClasses(string leadingIcon, string trailingIcon)
        {
            string classString = "";
            if (!string.IsNullOrWhiteSpace(leadingIcon)) { classString += " mdc-text-field--with-leading-icon"; }
            if (!string.IsNullOrWhiteSpace(trailingIcon)) { classString += " mdc-text-field--with-trailing-icon"; }
            return classString;
        }
    }
}
