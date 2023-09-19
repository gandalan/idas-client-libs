using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.Util
{
    public delegate object HandleValueMappingDelegate(object propertyValue);

    public class PropertyValueCollection : Dictionary<string, object>
    {
        private static Dictionary<string, HandleValueMappingDelegate> _mappingHandlers;

        public string TypeName { get; set; }

        public static PropertyValueCollection GetPropertyValuesFromObject(object o, string[] ignoreProps)
        {
            var result = new PropertyValueCollection();

            if (o != null)
            {
                result.TypeName = o.GetType().FullName.StartsWith("System.Data.Entity.DynamicProxies.") ? o.GetType().BaseType.FullName : o.GetType().FullName;
                foreach (var pi in o.GetType().GetProperties())
                {
                    if (ignoreProps != null && ignoreProps.Contains(pi.Name))
                        continue;

                    var value = pi.GetValue(o, null);
                    if (value != null)
                    {
                        var key = result.TypeName + "::" + pi.Name;
                        if (_mappingHandlers != null && _mappingHandlers.TryGetValue(key, out var handleDelegate))
                        {
                            value = handleDelegate(value);
                        }

                        result[pi.Name] = value;
                    }
                }
            }

            return result;
        }

        public void PutPropertyValuesToObject(object o, string[] ignoreProps)
        {
            PutPropertyValuesToObject(o, this, null, ignoreProps);
        }

        public void PutPropertyValuesToObject(object o, HandleSpecialValueMappingDelegate specialMappingHandler, string[] ignoreProps)
        {
            PutPropertyValuesToObject(o, this, specialMappingHandler, ignoreProps);
        }

        public static void PutPropertyValuesToObject(object o, PropertyValueCollection values, HandleSpecialValueMappingDelegate specialMappingHandler,
            string[] ignoreProps)
        {
            if (ignoreProps == null) ignoreProps = new string[] { "" };
            var targetObjectProps = o.GetType().GetProperties();

            foreach (var key in values.Keys.ToArray())
            {
                if (targetObjectProps.Any(p => p.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase) && p.CanWrite))
                {
                    var newValue = values[key];
                    if (specialMappingHandler != null)
                    {
                        newValue = specialMappingHandler(key, newValue) ?? newValue;
                    }

                    if (!ignoreProps.Contains(key))
                    {
                        try
                        {
                            var prop = targetObjectProps.Single(p => p.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase) && p.CanWrite);
                            prop.SetValue(o, newValue, null);
                        }
                        catch
                        {
                        }
                    }

                    values.Remove(key);
                }
            }
        }

        public static void RegisterMappingHandler(string propertyName, Type type, HandleValueMappingDelegate mappingHandler)
        {
            if (_mappingHandlers == null)
                _mappingHandlers = new Dictionary<string, HandleValueMappingDelegate>();

            var key = type.FullName.StartsWith("System.Data.Entity.DynamicProxies.") ? type.BaseType.FullName : type.FullName;

            _mappingHandlers[key + "::" + propertyName] = mappingHandler;
        }
    }
}
