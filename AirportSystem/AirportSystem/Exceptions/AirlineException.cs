using System;

namespace AirportSystem
{
    class AirlineException : Exception
    {
        public AirlineException() : base()
        {

        }
        public AirlineException(string message) : base(message)
        {

        }
        public AirlineException(string message, Exception e) : base(message, e)
        {

        }
    }
}
