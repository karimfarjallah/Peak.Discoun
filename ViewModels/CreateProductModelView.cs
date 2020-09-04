using Microsoft.AspNetCore.Http;
using Peak.Discount.Model;
using System.ComponentModel.DataAnnotations.Schema;

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
