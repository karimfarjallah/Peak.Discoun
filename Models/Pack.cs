using System.Collections.Generic;

namespace Peak.Discoun.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PackProduct> PackProducts { get; set; }
    }
}
