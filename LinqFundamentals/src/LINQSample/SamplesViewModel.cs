using LinqSamples.Common;
using LinqSamples.Common.HelperClasses;
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
                new
                {
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

        #region WhereQuery
        /// <summary>
        /// Filter products using where. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    where prod.Name.StartsWith("S")
                    select prod).ToList();

            return list;
        }
        #endregion

        #region WhereMethod
        /// <summary>
        /// Filter products using where. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.Where(prod => prod.Name.StartsWith("S")).ToList();

            return list;
        }
        #endregion

        #region WhereTwoFieldsQuery
        /// <summary>
        /// Filter products using where with two fields. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereTwoFieldsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    where prod.Name.StartsWith("L") && prod.StandardCost > 200
                    select prod).ToList();

            return list;
        }
        #endregion

        #region WhereTwoFieldsMethod
        /// <summary>
        /// Filter products using where with two fields. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereTwoFieldsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.Where(prod => prod.Name.StartsWith("L") && prod.StandardCost > 200).ToList();

            return list;
        }
        #endregion

        #region WhereExtensionsQuery
        public List<Product> WhereExtensionsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = (from prod in products
                    select prod).ByColor("RED").ToList();

            return list;
        }
        #endregion

        #region WhereExtensionsMethod
        public List<Product> WhereExtensionsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            list = products.ByColor("RED").ToList();

            return list;
        }
        #endregion

        #region FirstQuery
        /// <summary>
        /// Locate a specific product using First(). First() searches forward in the collection.
        /// NOTE: First() throws an exception if the result does not produce any values
        /// Use First() when you know or expect the sequence to have at least one element.
        /// Exceptions should be exceptional, so try to avoid them.
        /// </summary>
        public Product FirstQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products select prod).First(prod => prod.Color == "red");

            return value;
        }
        #endregion

        #region FirstMethod
        /// <summary>
        /// Locate a specific product using First(). First() searches forward in the collection.
        /// NOTE: First() throws an exception if the result does not produce any values
        /// Use First() when you know or expect the sequence to have at least one element.
        /// Exceptions should be exceptional, so try to avoid them.
        /// </summary>
        public Product FirstMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.First(prod => prod.Color == "red");

            return value;
        }
        #endregion

        #region FirstOrDefaultQuery
        /// <summary>
        /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
        /// NOTE: FirstOrDefault() returns a null if no value is found
        /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
        /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
        /// </summary>
        public Product FirstOrDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products select prod).FirstOrDefault(prod => prod.Color == "Red");

            return value;
        }
        #endregion

        #region FirstOrDefaultMethod
        /// <summary>
        /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
        /// NOTE: FirstOrDefault() returns a null if no value is found
        /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
        /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
        /// </summary>
        public Product FirstOrDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.FirstOrDefault(prod => prod.Color == "Red");

            return value;
        }
        #endregion

        #region FirstOrDefaultWithDefaultQuery
        /// <summary>
        /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
        /// NOTE: You may specify the return value with FirstOrDefault() if not found
        /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
        /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
        /// </summary>
        public Product FirstOrDefaultWithDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products
                     select prod).FirstOrDefault(prod => prod.Color == "red", new Product
                     {
                         ProductId = -1,
                         Name = "NOT FOUND"
                     });

            return value;
        }
        #endregion

        #region FirstOrDefaultWithDefaultMethod
        /// <summary>
        /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
        /// NOTE: You may specify the return value with FirstOrDefault() if not found
        /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
        /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
        /// </summary>
        public Product FirstOrDefaultWithDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.FirstOrDefault(prod => prod.Color == "red", new Product
            {
                ProductId = -1,
                Name = "NOT FOUND"
            });

            return value;
        }
        #endregion

        #region LastQuery
        /// <summary>
        /// Locate a specific product using Last(). Last() searches from the end of the list backwards.
        /// NOTE: Last returns the last value from a collection, or throws an exception if no value is found
        /// </summary>
        public Product LastQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products select prod).Last(prod => prod.Color == "red");

            return value;
        }
        #endregion

        #region LastMethod
        /// <summary>
        /// Locate a specific product using Last(). Last() searches from the end of the list backwards.
        /// NOTE: Last returns the last value from a collection, or throws an exception if no value is found
        /// </summary>
        public Product LastMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.Last(prod => prod.Color == "Red");

            return value;
        }
        #endregion

        #region LastOrDefaultQuery
        /// <summary>
        /// Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards.
        /// NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
        /// </summary>
        public Product LastOrDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products select prod).LastOrDefault(prod => prod.Color == "red", new Product
            {
                ProductId = -1,
                Name = "NOT FOUND"
            });

            return value;
        }
        #endregion

        #region LastOrDefaultMethod
        /// <summary>
        /// Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards.
        /// NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
        /// </summary>
        public Product LastOrDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.LastOrDefault(prod => prod.Color == "red", new Product
            {
                ProductId = -1,
                Color = "red",
            });

            return value;
        }
        #endregion

        #region SingleQuery
        /// <summary>
        /// Locate a specific product using Single().
        /// NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
        /// Single() always searches the complete collection
        /// </summary>
        public Product SingleQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products select prod).Single(prod => prod.ProductId == 706);

            return value;
        }
        #endregion

        #region SingleMethod
        /// <summary>
        /// Locate a specific product using Single().
        /// NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
        /// Single() always searches the complete collection
        /// </summary>
        public Product SingleMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.Single(prod => prod.ProductId == 706);

            return value;
        }
        #endregion

        #region SingleOrDefaultQuery
        /// <summary>
        /// Locate a specific product using SingleOrDefault()
        /// NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.
        /// SingleOrDefault() always searches the complete collection
        /// </summary>
        public Product SingleOrDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = (from prod in products select prod).SingleOrDefault(prod => prod.ProductId == 706, new Product
            {
                ProductId = -1,
                Name = "NOT FOUND"
            });

            return value;
        }
        #endregion

        #region SingleOrDefaultMethod
        /// <summary>
        /// Locate a specific product using SingleOrDefault()
        /// NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.
        /// SingleOrDefault() always searches the complete collection
        /// </summary>
        public Product SingleOrDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            value = products.SingleOrDefault(prod => prod.ProductId == 706, new Product
            {
                ProductId = -1,
                Name = "NOT FOUND"
            });

            return value;
        }
        #endregion
    }
}

