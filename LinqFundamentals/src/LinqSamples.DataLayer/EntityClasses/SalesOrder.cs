using System.Text;

namespace LinqSamples.DataLayer.EntityClasses
{
    public class SalesOrder
    {
        public int SalesOrderID { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }

        #region ToString Override
        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"Order Id: {SalesOrderID}");
            sb.AppendLine($" Product Id: {ProductId} Quantity: {OrderQty}");
            sb.AppendLine($" Unit Price: {UnitPrice:c} Total: {LineTotal:c}");

            return sb.ToString();
        }
        #endregion
    }
}
