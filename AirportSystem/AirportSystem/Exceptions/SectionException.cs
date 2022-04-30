using System;

namespace AirportSystem
{
    class SectionException : Exception
    {
        public SectionException() : base()
        {

        }
        public SectionException(string message) : base(message)
        {

        }
        public SectionException(string message, Exception e) : base(message, e)
        {

        }
    }
}
