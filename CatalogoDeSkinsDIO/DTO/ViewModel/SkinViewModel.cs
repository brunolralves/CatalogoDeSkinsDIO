
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.DTO.ViewModel
{
    public class SkinViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PackageName { get; set; }

        public double Price { get; set; }
    }
}
