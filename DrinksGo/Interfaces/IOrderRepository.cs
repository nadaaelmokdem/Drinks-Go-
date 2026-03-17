using Drinks_Go.Models;

namespace Drinks_Go.Interfaces
{
    public interface IOrderRepository
    {
        void createOrder(Order order);

    }
}
