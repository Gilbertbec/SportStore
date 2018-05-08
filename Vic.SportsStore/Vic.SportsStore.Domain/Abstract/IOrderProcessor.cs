namespace Vic.SportsStore.Domain.Abstract
{
    using Vic.SportsStore.Domain.Entities;

    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
