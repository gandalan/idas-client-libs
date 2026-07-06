using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }

    extension<T>(T) where T : Enum
    {
        public static Dictionary<T, string> GetDisplaySourceDictionary()
            => Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(x => x, x => x.GetDescription());
    }
}
