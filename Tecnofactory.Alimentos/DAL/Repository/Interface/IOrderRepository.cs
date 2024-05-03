using System.Linq.Expressions;
using Tecnofactory.Alimentos.DAL.Entity;

namespace Tecnofactory.Alimentos.DAL.Repository.Interface
{
    public interface IOrderRepository
    {
        Guid Create(Order order);
        List<Order> Get();
        List<Order> Get(Expression<Func<Order, bool>> predicate);
        void Update(Order order);
        void Delete(Order order);
    }
}
