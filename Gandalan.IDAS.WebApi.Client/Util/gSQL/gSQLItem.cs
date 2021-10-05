namespace Gandalan.IDAS.WebApi.Util.gSQL
{
    public class gSQLItem
	{
        public gSQLItem()
        {
        }

        public gSQLItem(string name, string wert)
        {
            Name = name;
            Wert = wert;
        }

        public string Name { get; set; }
		public string Wert { get; set; }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(Name) ? $"    {Name,-66}:{Wert}" : "";
        }
    }
}
