using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gandalan.IDAS.WebApi.Util.gSQL
{
    public class gSQLInhalt
    {
        public List<gSQLSektion> Sektionen { get; set; }

        public gSQLInhalt()
        {
            Sektionen = [];
        }

        public gSQLSektion GetSektion(string sektion)
        {
            return Sektionen.FirstOrDefault(s => s.Name != null && s.Name.Equals(sektion, StringComparison.InvariantCultureIgnoreCase));
        }

        public string GetItem(string sektion, string itemName, string defaultWert = null)
        {
            var sek = GetSektion(sektion);
            if (sek != null)
            {
                return sek.GetItemWert(itemName, defaultWert);
            }

            return defaultWert;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var sektion in Sektionen)
            {
                sb.AppendLine(sektion.Name);
                foreach (var item in sektion.Items)
                {
                    sb.AppendLine(item.ToString());
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
