namespace System
{
    public static class TypeExtension
    {
        public static Type GetUnproxiedType(this object o)
        {
            Type t = o.GetType();

            /* EF6: System.Data.Entity.DynamicProxies.xxx
             * EF Core: Castle.Proxies.xxx
             */
            return t.FullName.Contains("Proxies.") ? t.BaseType : t;
        }
    }
}
