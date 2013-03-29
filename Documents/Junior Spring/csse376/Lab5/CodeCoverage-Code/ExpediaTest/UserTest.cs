
using System;
using NUnit.Framework;
using Expedia;

namespace ExpediaTest
{
	[TestFixture()]
	public class UserTest
	{
		private User target;
		private readonly DateTime StartDate = new DateTime(2009, 11, 1);
		private readonly DateTime EndDate = new DateTime(2009, 11, 30);

        private User target2;
        private readonly DateTime StartDate2 = new DateTime(2009, 11, 1);
        private readonly DateTime EndDate2 = new DateTime(2009, 11, 30);
		
		[SetUp()]
		public void Setup()
		{
			target = new User("Bob Dole");
            target2 = new User("Bob Dole", 1000000);
		}


		[Test()]
		public void TestThatUserInitializes()
		{
			Assert.AreEqual("Bob Dole", target.Name);
		}
		
		[Test()]
		public void TestThatUserHasZeroFrequentFlierMilesOnInit()
		{
			Assert.AreEqual(0, target.FrequentFlierMiles);
		}
		
		[Test()]
		public void TestThatUserCanBookEverything()
		{
			target.book(new Flight(StartDate, EndDate, 0), new Hotel(5), new Car(3));
			Assert.AreEqual(3, target.Bookings.Count);
		}
		
		[Test()]
		public void TestThatUserHasFrequentFlierMilesAfterBooking()
		{
			target.book(new Flight(StartDate, EndDate, 1), new Hotel(5), new Car(3));
			Assert.Less(0, target.FrequentFlierMiles);
			Assert.AreEqual(3, target.Bookings.Count);
		}
		
		[Test()]
		public void TestThatUserCanBookAFlight()
		{
			target.book(new Flight(StartDate, EndDate, 0));
			Assert.AreEqual(1, target.Bookings.Count);
		}
		
		[Test()]
		public void TestThatUserCanBookAHotelAndACar()
		{
			target.book(new Car(5), new Hotel(5));
			Assert.AreEqual(2, target.Bookings.Count);
		}
		
		[Test()]
		public void TestThatUserHasCorrectNumberOfFrequentFlyerMilesAfterOneFlight()
		{
			target.book(new Flight(StartDate, EndDate, 500));
			Assert.AreEqual(500, target.FrequentFlierMiles);
		}

        [Test()]
        public void TestDoubleFrequentFlyerMiles()
        {
            target.bookWithDoubleMiles(new Flight(StartDate, EndDate, 5001));
            // You can only get 5000 bonus miles per flight, so "doubling" 5001 just gives us 10001
            Assert.AreEqual(10001, target.FrequentFlierMiles);
        }

        [Test()]
        public void TestGreeting()
        {
            String greeting = target.customerGreeting();
            Assert.AreEqual("Hello Bob Dole", greeting);
        }

        [Test()]
        public void TestGreetingLotsOfMiles()
        {
            String greeting = target2.customerGreeting();
            Assert.AreEqual("Hello Bob Dole, we're SUPER excited to see you!", greeting);
        }
		
		[TearDown()]
		public void TearDown()
		{
			target = null; // this is entirely unnecessary.. but I'm just showing a usage of the TearDown method here
		}
	}
}
