using DAL.DbContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.OrderSystem
{
    public class DbCollectionGateway : IDbCollectionGateway
    {
        private readonly AppDbContext myAppDbContext;

        public DbCollectionGateway(AppDbContext appDbContext)
        {
            myAppDbContext = appDbContext;
        }

        public async Task<int> CreateOrder(Order order)
        {
            await myAppDbContext.Orders.AddAsync(order);
            return await myAppDbContext.SaveChangesAsync();
        }

        public async Task<bool> OrderExists(int id)
        {
            return await myAppDbContext.Orders.AnyAsync(b => b.Id == id);
        }

        public async Task<int> CreateItem(Item item)
        {
             await myAppDbContext.Items.AddAsync(item);
             return await myAppDbContext.SaveChangesAsync();
        }

        public async Task<bool> ItemExists(int id)
        {
            return await myAppDbContext.Items.AnyAsync(i => i.Id == id);
        }
    }
}
