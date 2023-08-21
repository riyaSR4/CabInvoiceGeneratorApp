namespace CabInvoiceGeneratorApp
{
    public class InvoiceService
    {
        private const int COST_PER_KM = 10;
        private const int MIN_FARE = 5;
        private const int COST_PER_MIN = 1;

        public double CalculateFare(double distance, double time)
        {
            double totalAmount = distance * COST_PER_KM + time * COST_PER_MIN;
            if(totalAmount > MIN_FARE)
            {
                return totalAmount;
            }
            return MIN_FARE;
        }
    }
}