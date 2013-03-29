using System;
using NUnit.Framework;
using Expedia;

namespace ExpediaTest
{
    [TestFixture()]
    class HotelTest
    {
        private readonly int NightsToRentHotel = 5;

        [Test()]
        public void TestThatHotelInitializes()
        {
            var target = new Hotel(NightsToRentHotel);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatHotelHasCorrectBasePriceForOneDayStay()
        {
            var target = new Hotel(1);
            Assert.AreEqual(45, target.getBasePrice());
        }

        [Test()]
        public void TestThatHotelHasCorrectBasePriceForTwoDayStay()
        {
            var target = new Hotel(2);
            Assert.AreEqual(90, target.getBasePrice());
        }

        [Test()]
        public void TestThatHotelHasCorrectBasePriceForTenDaysStay()
        {
            var target = new Hotel(10);
            Assert.AreEqual(450, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatHotelThrowsOnBadLength()
        {
            new Hotel(-5);
        }

        [Test()]
        public void TestHotelEqualsTrue()
        {
            var target = new Hotel(NightsToRentHotel);
            var target2 = new Hotel(NightsToRentHotel);
            Assert.True(target.Equals(target2));
        }

        [Test()]
        public void TestHotelEqualsFalse()
        {
            var target = new Hotel(NightsToRentHotel);
            var target2 = new Hotel(2*(NightsToRentHotel+1));
            Assert.False(target.Equals(target2));
        }

        [Test()]
        public void TestHotelEqualsCar()
        {
            var target = new Hotel(NightsToRentHotel);
            var target2 = new Car(NightsToRentHotel);
            Assert.False(target.Equals(target2));
        }

    }
}
