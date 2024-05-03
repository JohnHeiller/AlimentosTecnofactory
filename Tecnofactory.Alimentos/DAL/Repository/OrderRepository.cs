using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tecnofactory.Alimentos.DAL.Entity;
using Tecnofactory.Alimentos.DAL.Repository.Interface;

namespace Tecnofactory.Alimentos.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Create(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order.Id;
        }

        public List<Order> Get()
        {
            return _dbContext.Orders
                .AsNoTracking()
                .ToList();
        }

        public List<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            return _dbContext.Orders
                .Where(predicate)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
