using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Product
{
    public class ProductFilterDTO
    {
        public string? Name { get;set; }
        public decimal? ToPrice { get; set; }
        public decimal? FromPrice { get; set; }
        public int? CategoryId { get;set; }
        public string? SortType { get; set; }
    }
}
