using System;
using NUnit.Framework;
using Expedia;

namespace ExpediaTest
{
    [TestFixture()]
    class FlightTest
    {
        [Test()]
        public void TestThatFlightInitializes()
        {
            DateTime StartDate = new DateTime(2009, 11, 1);
            DateTime EndDate = new DateTime(2009, 11, 1);
            var target = new Flight(StartDate, EndDate, 700);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFlightEndBeforeStart()
        {
            DateTime StartDate = new DateTime(2009, 11, 2);
            DateTime EndDate = new DateTime(2009, 11, 1);
            var target = new Flight(StartDate, EndDate, 700);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFlightNegativeMiles()
        {
            DateTime StartDate = new DateTime(2009, 11, 1);
            DateTime EndDate = new DateTime(2009, 11, 2);
            var target = new Flight(StartDate, EndDate, -700);
        }

        [Test()]
        public void TestFlightEqualsTrue()
        {
            DateTime StartDate = new DateTime(2009, 11, 1);
            DateTime EndDate = new DateTime(2009, 11, 1);
            var target = new Flight(StartDate, EndDate, 700);
            var target2 = new Flight(StartDate, EndDate, 700);
            Assert.True(target.Equals(target2));
        }

        [Test()]
        public void TestFlightEqualsHotel()
        {
            DateTime StartDate = new DateTime(2009, 11, 1);
            DateTime EndDate = new DateTime(2009, 11, 1);
            var target = new Flight(StartDate, EndDate, 700);
            var target2 = new Car(5);
            Assert.False(target.Equals(target2));
        }
    }
}
