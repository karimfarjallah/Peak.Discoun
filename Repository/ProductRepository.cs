﻿using Peak.Discoun.Context;
using Peak.Discoun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discoun.Repository
{
    public class ProductRepository : IProductRepository

    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product Add(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Delete(int Id)
        {
            Product product = context.Product.Find(Id);
            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return context.Product;
        }

        public Product GetProductById(int Id)
        {
            return context.Product.Find(Id);
        }

        public Product Update(Product productChanges)
        {
            var product = context.Product.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }
    }
}
