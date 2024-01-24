using LinqSamples.DataLayer.EntityClasses;

namespace LinqSamples.Common.HelperClasses
{
    public static class ProductHelper
    {
        #region ByColor
        public static IEnumerable<Product> ByColor(this IEnumerable<Product> query, string color)
        {
            return query.Where(p => p.Color == color);
        }
        #endregion
    }
}
