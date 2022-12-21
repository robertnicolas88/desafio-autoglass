using DesafioAutoGlass.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Core.DTOs
{
    public class ProductListDto
    {
        public List<Product> Products { get; set; }
        public int Count { get; set; }
    }
}
