using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peak.Discoun.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateExpire { get; set; }

        public int secondes { get; set; }

        public List<PackProduct> PackProducts { get; set; }
    }
}
