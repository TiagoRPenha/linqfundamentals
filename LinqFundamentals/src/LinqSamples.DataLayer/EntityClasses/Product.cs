﻿using System.Text;

namespace LinqSamples.DataLayer.EntityClasses
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }

        public int? NameLength { get; set; }
        public decimal? TotalSales { get; set; }

        #region ToString Override 
        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"{Name}  ID: {ProductId}");
            sb.AppendLine($"   Color: {Color}   Size: {(Size ?? "n/a")}");
            sb.AppendLine($"   Cost: {StandardCost:c}   Price: {ListPrice:c}");
            if (NameLength.HasValue)
            {
                sb.AppendLine($"   Name Length: {NameLength}");
            }
            if (TotalSales.HasValue)
            {
                sb.AppendLine($"   Total Sales: {TotalSales:c}");
            }
            return sb.ToString();
        }
        #endregion
    }
}



