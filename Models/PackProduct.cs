using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peak.Discount.Dashboard.Models
{
    public class PackProduct
    { 
        public int PackId { get; set; }
    
        public int ProductId { get; set; }

        public Pack Pack { get; set; }
        public Product Product { get; set; }

    }
}
