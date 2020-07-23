using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.Exceptions
{
    public class DuplicateValueException : Exception
    {
        public DuplicateValueException(string message)
       : base(message)
        {
        }
    }
}
