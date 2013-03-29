using System;
using System.Collections.Generic;
using System.Collections;

namespace Expedia
{
    public class User
    {
        public User(String aName)
        {
            Name = aName;
            Bookings = new List<Booking>();
            bonusFrequentFlierMiles = 0;
        }

        public User(String aName, Int32 FreqFlyMiles)
        {
            Name = aName;
            Bookings = new List<Booking>();
            bonusFrequentFlierMiles = FreqFlyMiles;
        }

        public String Name
        {
            get;
            private set;
        }

        public Int32 FrequentFlierMiles
        {
            get
            {
                var result = 0;
                foreach (var booking in Bookings)
                {
                    result = result + milesForBooking(booking);
                }
                return result + bonusFrequentFlierMiles;
            }
        }

        private static int milesForBooking(Booking booking)
        {
            if (booking.GetType() == typeof(Flight))
            {
                return  ((Flight)booking).Miles;
            }
            return 0;
        }

        private Int32 bonusFrequentFlierMiles;

        public List<Booking> Bookings
        {
            get;
            private set;
        }

        public void book(params Booking[] bookings)
        {
            foreach (var booking in bookings)
            {
                Bookings.Add(booking);
            }
        }

        public String customerGreeting()
        {
            String greeting = "Hello " + Name;
            if (FrequentFlierMiles > 500000)
            {
                greeting += ", we're SUPER excited to see you!";
            }
            return greeting;
        }

        public void bookWithDoubleMiles(params Booking[] bookings)
        {
            book(bookings);
            foreach (var booking in bookings)
            {
                if (milesForBooking(booking) > 5000)
                {
                    // flight rules say you can't earn more than 5000 double miles for each flight
                    bonusFrequentFlierMiles += 5000;
                }
            }
        }
    }
}
