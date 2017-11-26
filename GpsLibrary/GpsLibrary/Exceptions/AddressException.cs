using System;

namespace GpsLibrary.Exceptions
{
    public class AddressException : Exception
    {
        public AddressException(string message)
        : base(message)
        {

        }

        public AddressException()
        {

        }
    }
}
