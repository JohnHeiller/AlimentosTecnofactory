using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.BL.Interface
{
    public interface IOrderCreationService
    {
        Task<bool> AddUserOrder(UserOrderDto userOrder);
        List<UserOrderDto> GetAllOrders();
    }
}
