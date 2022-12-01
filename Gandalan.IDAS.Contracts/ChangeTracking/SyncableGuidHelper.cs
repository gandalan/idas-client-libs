using Gandalan.IDAS.Contracts.ChangeTracking;
using System.Collections.Generic;
using System.Reflection;

namespace System
{
    public static class SyncableGuidHelper
    {
        private static Dictionary<Type, PropertyInfo> guidProperties = new Dictionary<Type, PropertyInfo>();

        public static Guid GetGuid(this object o)
        {
            if (o is Guid guid)
            {
                return guid;
            }

            PropertyInfo guidProperty = GetGuidProperty(o.GetUnproxiedType());
            return guidProperty != null ? (Guid)guidProperty.GetValue(o, null) : Guid.Empty;
        }

        public static Guid TryGetGuid(this object o)
        {
            if (o is Guid guid)
            {
                return guid;
            }

            PropertyInfo guidProperty = TryGetGuidProperty(o.GetUnproxiedType());
            return guidProperty != null ? (Guid)guidProperty.GetValue(o, null) : Guid.Empty;
        }

        public static void SetGuid(this object o, Guid newSyncableGuid)
        {
            PropertyInfo guidProperty = GetGuidProperty(o.GetUnproxiedType());
            if (guidProperty != null)
            {
                guidProperty.SetValue(o, newSyncableGuid, null);
            }
        }

        public static PropertyInfo GetGuidProperty(Type t)
        {
            lock (guidProperties)
            {
                if (!guidProperties.ContainsKey(t))
                {
                    string propertyName = null;
                    SyncableAttribute attrib = t.GetCustomAttribute<SyncableAttribute>(true);
                    if (attrib != null)
                    {
                        propertyName = attrib.GuidColumnName;
                    }
                    else if (t.Name.Contains("DTO"))
                    {
                        propertyName = t.Name.Replace("DTO", "") + "Guid";
                    }
                    else
                    {
                        throw new InvalidOperationException("Entität hat kein Syncable-Attribut");
                    }

                    if (!string.IsNullOrEmpty(propertyName))
                    {
                        PropertyInfo guidProperty = t.GetProperty(propertyName);
                        if (guidProperty == null)
                        {
                            throw new InvalidOperationException($"Spalte {propertyName} nicht in Typ {t.FullName} enthalten");
                        }

                        if (guidProperty.PropertyType != typeof(Guid))
                        {
                            throw new InvalidOperationException($"Spalte {propertyName} in Typ {t.FullName} ist keine Guid");
                        }

                        guidProperties.Add(t, guidProperty);
                    }
                    else
                    {
                        throw new InvalidOperationException("Spalte mit Guid nicht gefunden");
                    }
                }
            }

            return guidProperties[t];
        }

        public static PropertyInfo TryGetGuidProperty(Type t)
        {
            lock (guidProperties)
            {
                if (!guidProperties.ContainsKey(t))
                {
                    SyncableAttribute attrib = t.GetCustomAttribute<SyncableAttribute>(true);
                    string propertyName;
                    if (attrib != null)
                    {
                        propertyName = attrib.GuidColumnName;
                    }
                    else if (t.Name.Contains("DTO"))
                    {
                        propertyName = t.Name.Replace("DTO", "") + "Guid";
                    }
                    else
                    {
                        propertyName = t.Name + "Guid";
                    }

                    if (!string.IsNullOrEmpty(propertyName))
                    {
                        PropertyInfo guidProperty = t.GetProperty(propertyName);
                        if (guidProperty == null)
                        {
                            return null;
                        }

                        if (guidProperty.PropertyType != typeof(Guid))
                        {
                            throw new InvalidOperationException($"Spalte {propertyName} in Typ {t.FullName} ist keine Guid");
                        }

                        guidProperties.Add(t, guidProperty);
                    }
                    else
                    {
                        throw new InvalidOperationException("Spalte mit Guid nicht gefunden");
                    }
                }
            }

            return guidProperties[t];
        }

        public static bool IsSyncable(this object o)
        {
            return o.GetType().GetCustomAttribute<SyncableAttribute>(true) != null;
        }

        public static bool IsSyncable(this Type t)
        {
            return t.GetCustomAttribute<SyncableAttribute>(true) != null;
        }
    }
}
