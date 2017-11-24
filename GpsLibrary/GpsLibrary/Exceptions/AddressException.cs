using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLibrary.Exceptions
{
    public class AddressException: Exception
    {
        public AddressException(string message)
        : base(message)
        {

        }
    }
}
