using System;

namespace AirportSystem
{
    class FlightException : Exception
    {
        public FlightException() : base()
        {

        }
        public FlightException(string message) : base(message)
        {

        }
        public FlightException(string message, Exception e) : base(message, e)
        {

        }
    }
}
