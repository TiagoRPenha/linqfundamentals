using LinqSamples.DataLayer.EntityClasses;

namespace LinqSamples.Common.ComparerClasses
{
    public class ProductIdComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product? x, Product? y)
        {
            return (x.ProductId == y.ProductId);
        }

        public override int GetHashCode(Product obj)
        {
            return obj.ProductId.GetHashCode();
        }       
    }
}
