using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts;
public interface IWithGueltigkeitsZeitraum
{
    public DateTime? GueltigAb { get; }
    public DateTime? GueltigBis { get; }
}
