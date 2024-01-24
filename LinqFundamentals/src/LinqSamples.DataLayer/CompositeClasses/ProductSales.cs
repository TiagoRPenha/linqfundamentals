using LinqSamples.DataLayer.EntityClasses;

namespace LinqSamples.DataLayer.CompositeClasses
{
    public class ProductSales
    {
        public Product Product { get; set; }
        public List<SalesOrder> Sales { get; set; }
    }
}
