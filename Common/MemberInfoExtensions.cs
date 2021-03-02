using System;
using System.Reflection;

namespace Common
{
    public static class MemberInfoExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo self, bool inherit = false)
            where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(self, typeof(TAttribute), inherit);
        }
    }
}
