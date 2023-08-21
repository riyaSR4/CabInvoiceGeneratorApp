namespace CabInvoiceGeneratorApp
{
    public class InvoiceService
    {
        private const int COST_PER_KM = 10;
        private const int MIN_FARE = 5;
        private const int COST_PER_MIN = 1;
        public int totalNumOfRides = 0;
        public double totalFare = 0;
        public double averageFare = 0;
        public int TotalNumOfRides()
        {
            return totalNumOfRides;
        }
        public double TotalFare()
        {
            return totalFare;
        }
        public double AverageFare()
        {
            return averageFare;
        }

        public double CalculateFare(double distance, double time)
        {
            double totalAmount = distance * COST_PER_KM + time * COST_PER_MIN;
            if(totalAmount > MIN_FARE)
            {
                return totalAmount;
            }
            return MIN_FARE;
        }
        public double CalculateFare(Ride[] rides)
        {
            foreach(var  ride in rides)
            {
                totalFare += (ride.Distance * COST_PER_KM + ride.Time * COST_PER_MIN);
            }
            totalNumOfRides = rides.Length;
            averageFare = totalFare / totalNumOfRides;
            return averageFare;
        }
    }
}