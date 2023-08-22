using CabInvoiceGeneratorApp;

namespace CabInvoiceGeneratorAppTest
{
    public class Tests
    {
        InvoiceService invoiceService = new InvoiceService();
        [Test]
        public void GivenDistanceAndTime_WhenChecked_ReturnTotalFare()
        {
            double actual = invoiceService.CalculateFare(10, 5);
            double expected = 105;
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void GivenRides_WhenChecked_ReturnTotalFare()
        {
            Ride[] ride =
            {
                new Ride(){Distance = 10, Time = 5, RideType="NORMAL"}
            };
            double actual = invoiceService.CalculateFare(ride);
            double expected = 105;
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void GivenRides_WhenChecked_ReturnTotalRides()
        {
            Ride[] ride =
            {
                new Ride(){Distance = 10, Time = 5, RideType = "NORMAL"},
                new Ride(){Distance = 10, Time = 5, RideType = "PREMIUM"}
            };
            invoiceService.CalculateFare(ride);
            int actual = invoiceService.TotalNumOfRides();
            int expected = ride.Length;
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void GivenRidesWithUserId_WhenChecked_ReturnTotalRides()
        {
            string userId = "Riya";
            Ride[] ride =
            {
                new Ride(){Distance = 10, Time = 5, RideType = "NORMAL"}
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            double actual = invoiceService.CalculateFare(rideRepository.GetRides(userId));
            double expected = 105;
            Assert.AreEqual(actual, expected);
        }
    }
}