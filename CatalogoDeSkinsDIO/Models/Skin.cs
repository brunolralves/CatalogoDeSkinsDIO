using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Models
{
    public class Skin
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PackageName { get; set; }

        public double Price { get; set; }
    }
}
