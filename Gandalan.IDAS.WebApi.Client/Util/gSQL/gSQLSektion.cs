using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.Util.gSQL
{
    public class gSQLSektion
    {
        public string Name { get; set; }
        public List<gSQLItem> Items { get; set; }

        public gSQLSektion()
        {
            Items = [];
        }

        public gSQLSektion(string name) : this()
        {
            Name = name;
        }

        internal gSQLItem GetItem(string itemName)
        {
            return Items.FirstOrDefault(i => i.Name != null && i.Name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase));

        }

        public string GetItemWert(string itemName, string defaultWert = null)
        {
            var item = GetItem(itemName);
            return item != null ? item.Wert : defaultWert;
        }
    }
}
