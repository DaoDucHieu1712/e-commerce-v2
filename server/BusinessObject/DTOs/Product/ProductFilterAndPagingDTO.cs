using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Product
{
    public class ProductFilterAndPagingDTO
    {
        public List<ProductDTO>? Products { get;set; }
        public int? Total { get; set; }
        public int? PageIndex { get; set; }
        
    }
}
