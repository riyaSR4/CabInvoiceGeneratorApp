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
    }
}