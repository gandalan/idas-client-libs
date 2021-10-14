namespace System
{
    public static class ContainsInsensitive
    {
        public static bool Contains(this string source, string needle, StringComparison comp)
        {
            return source?.IndexOf(needle, comp) >= 0;
        }
    }
}
