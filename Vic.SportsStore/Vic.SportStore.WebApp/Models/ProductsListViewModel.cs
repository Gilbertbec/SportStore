namespace Vic.SportsStore.WebApp.Models
{
    using System.Collections.Generic;
    using Vic.SportsStore.Domain.Entities;

    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
