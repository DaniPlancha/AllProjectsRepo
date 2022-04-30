using System;

namespace AirportSystem
{
    class AirportException : Exception
    {
        public AirportException() : base()
        {

        }
        public AirportException(string message) : base(message)
        {

        }
        public AirportException(string message, Exception e) : base(message, e)
        {

        }
    }
}
