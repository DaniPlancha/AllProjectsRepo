using System;
using AirportDBFirst;

namespace AirportSystem
{
    class Program
    {
        public static void Main()
        {
            var data = new airportsystemContext();
            var res = new SystemManager(data);
            res.BookSeat(1, SeatClass.First, 2, 'A');
        }
    }
}
