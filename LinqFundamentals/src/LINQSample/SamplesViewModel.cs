using LinqSamples.Common;
using LinqSamples.DataLayer.EntityClasses;
using System.Text;

namespace LINQSample
{
    public class SamplesViewModel : ViewModelBase
    {
        #region GetAllQuery
        public List<Product> GetAllQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products select prod).ToList();

            return list;
        }
        #endregion

        #region GetAllMethod
        public List<Product> GetAllMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.Select(prod => prod).ToList();

            return list;
        }
        #endregion

        #region GetSingleColumnQuery
        public List<string> GetSingleColumnQuery()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            list.AddRange(from prod in products select prod.Name);

            return list;
        }
        #endregion

        #region GetSingleColumnMethod
        public List<string> GetSingleColumnMethod()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            list.AddRange(products.Select(prod => prod.Name));

            return list;
        }
        #endregion

        #region GetSpecificColumnsQuery
        public List<Product> GetSpecificColumnsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    select new Product
                    {
                        ProductId = prod.ProductId,
                        Name = prod.Name,
                        Size = prod.Size
                    }).ToList();

            return list;
        }
        #endregion

        #region GetSpecificColumnsMethod
        public List<Product> GetSpecificColumnsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.Select(prod => new Product
            {
                ProductId = prod.ProductId,
                Name = prod.Name,
                Size = prod.Size
            }).ToList();

            return list;
        }
        #endregion

        #region AnonymousClassQuery
        public string AnonymousClassQuery()
        {
            List<Product> products = GetProducts();
            StringBuilder sb = new(2048);

            var list = (from prod in products
                        select new
                        {
                            Identifier = prod.ProductId,
                            ProductName = prod.Name,
                            ProductSize = prod.Size
                        });

            foreach (var prod in list)
            {
                sb.AppendLine($"Product ID: {prod.Identifier}");
                sb.AppendLine($" Product Name: {prod.ProductName}");
                sb.AppendLine($" Product Size: {prod.ProductSize}");
            }

            return sb.ToString();
        }
        #endregion

        #region AnonymousClassMethod
        public string AnonymousClassMethod()
        {
            List<Product> products = GetProducts();
            StringBuilder sb = new(2048);

            var list = products.Select(prod =>
                new {
                    Identifier = prod.ProductId,
                    ProductName = prod.Name,
                    ProductSize = prod.Size
                }).ToList();

            foreach (var prod in list)
            {
                sb.AppendLine($"Product ID: {prod.Identifier}");
                sb.AppendLine($" Product Name: {prod.ProductName}");
                sb.AppendLine($" Product Size: {prod.ProductSize}");
            }

            return sb.ToString();
        }

        #endregion

        #region OrderByQuery
        public List<Product> OrderByQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    orderby prod.Name
                    select prod).ToList();

            return list;
        }
        #endregion

        #region OrderByMethod
        public List<Product> OrderByMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.OrderBy(prod => prod.Name).ToList();

            return list;
        }
        #endregion

        #region OrderByDescendingQuery
        public List<Product> OrderByDescendingQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    orderby prod.Name descending
                    select prod).ToList();

            return list;
        }
        #endregion

        #region OrderByDescendingMethod
        public List<Product> OrderByDescendingMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.OrderByDescending(prod => prod.Name).ToList();

            return list;
        }
        #endregion

        #region OrderByTwoFieldsQuery
        public List<Product> OrderByTwoFieldsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    orderby prod.Color, prod.Name ascending
                    select prod).ToList();

            return list;
        }
        #endregion

        #region OrderByTwoFieldsMethod
        public List<Product> OrderByTwoFieldsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.OrderBy(prod => prod.Color).ThenBy(prod => prod.Name).ToList();

            return list;
        }
        #endregion
    }
}
