using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Peak.Discoun.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateExpire { get; set; }
      
        public List<PackProduct> PackProducts { get; set; }
    }
}
