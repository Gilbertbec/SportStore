namespace Vic.SportsStore.Domain.Abstract
{
    using System.Collections.Generic;
    using Vic.SportsStore.Domain.Entities;

    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
