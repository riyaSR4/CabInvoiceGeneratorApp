namespace CabInvoiceGeneratorApp
{
    public class InvoiceService
    {
        private const int COST_PER_KM_NORMAL = 10;
        private const int MIN_FARE_NORMAL = 5;
        private const int COST_PER_MIN_NORMAL = 1;
        private const int COST_PER_KM_PREMIUM = 15;
        private const int MIN_FARE_PREMIUM = 20;
        private const int COST_PER_MIN_PREMIUM = 2;
        private const string NORMAL = "NORMAL";
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
            double totalAmount = distance * COST_PER_KM_NORMAL + time * COST_PER_MIN_NORMAL;
            if (totalAmount > MIN_FARE_NORMAL)
            {
                return totalAmount;
            }
            return MIN_FARE_NORMAL;
        }
        public double CalculateFare(string rideType, double distance, double time)
        {
            double totalAmount = 0;
            if (rideType.Equals(NORMAL))
            {
                totalAmount = distance * COST_PER_KM_NORMAL + time * COST_PER_MIN_NORMAL;
                if (totalAmount > MIN_FARE_NORMAL)
                {
                    return totalAmount;
                }
                return MIN_FARE_NORMAL;
            }
            totalAmount = distance * COST_PER_KM_PREMIUM + time * COST_PER_MIN_PREMIUM;
            if (totalAmount > MIN_FARE_PREMIUM)
            {
                return totalAmount;
            }
            return MIN_FARE_PREMIUM;
        }
        public double CalculateFare(Ride[] rides)
        {
            totalFare = 0;
            foreach (var ride in rides)
            {
                totalFare += CalculateFare(ride.RideType,ride.Distance,ride.Time);
            }
            totalNumOfRides = rides.Length;
            averageFare = totalFare / totalNumOfRides;
            return averageFare;
        }
    }
}