using Microsoft.AspNetCore.Http;
using Peak.Discoun.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discount.Dashboard.ViewModels
{
    public class CreateProductModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Stock { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        
        public Pack? Pack { get; set; }
    }
}
