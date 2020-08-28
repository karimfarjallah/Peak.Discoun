using Peak.Discoun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discoun.Repository
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
