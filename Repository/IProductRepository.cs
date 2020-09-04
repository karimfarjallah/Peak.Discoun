using Peak.Discount.Model;
using System.Collections.Generic;

namespace Peak.Discount.Dashboard.Repository
{
    public  interface IProductRepository
    {
        Product GetProductById(int Id);
        IEnumerable<Product> GetAllProduct();
        Product Add(Product product);
        Product Update(Product productChanges);
        Product Delete(int Id);
    }
}
