using LinqSamples.DataLayer.EntityClasses;

namespace LinqSamples.DataLayer.CompositeClasses
{
    public class SaleProducts
    {
        public int SalesOrderId { get; set; }
        public List<Product> Products { get; set; }
    }
}
