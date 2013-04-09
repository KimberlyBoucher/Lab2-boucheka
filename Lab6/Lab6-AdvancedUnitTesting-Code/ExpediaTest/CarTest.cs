using System;
using NUnit.Framework;
using Expedia;
using System.Collections.Generic;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[Test()]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [Test()]
        public void TestThatCarDoesGetLocationFromTheDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            String carLocation = "Parking lot A53, row 6, next to the rabid squirrels' nest";
            String anotherCarLocation = "Forever lost";
            using (mocks.Record())
            {
                // The mock will return "Whale Rider" when the call is made with 24
                mockDatabase.getCarLocation(24);
                LastCall.Return(carLocation);
                // The mock will return "Raptor Wrangler" when the call is made with 1025
                mockDatabase.getCarLocation(1025);
                LastCall.Return(anotherCarLocation);
            }
            var target = new Car(10);
            target.Database = mockDatabase;

            String result;

            result = target.getCarLocation(1025);
            Assert.AreEqual(result, anotherCarLocation);

            result = target.getCarLocation(24);
            Assert.AreEqual(result, carLocation);
        }

        [Test()]
        public void TestThatCarDoesGetMileageCountFromDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            int Miles = 150;
            mockDatabase.Miles = Miles;
            var target = new Car(10);
            target.Database = mockDatabase;
            int Mileage = target.Mileage;
            Assert.AreEqual(Mileage, Miles);
        }

        [Test()]
        public void TestThatCarDoesGetMileageCountFromDatabaseWithObjectMother()
        {
            var target = ObjectMother.BMW();
            String Name = target.Name;
            Assert.AreEqual(Name, "BMW 2013 Luxury Midsize car");
        }
	}
}
