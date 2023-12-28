using Clothings_Store.Data;
using Clothings_Store.Models.Database;
using Clothings_Store.Repositories;

namespace Clothings_Store.Interface;
public interface IUnitOfWork
{
    public StoreContext context { get; }
    IRepository<Order> OrderRepository { get; }
    IRepository<Product> ProductRepository { get; }
    IRepository<OrderDetail> OrderDetailsRepository { get; }
    void SaveChanges();
}
public class UnitOfWork : IUnitOfWork
{
    public StoreContext context { get; }

    public UnitOfWork(StoreContext context) => this.context = context;

    private IRepository<Order> orderRepository;
    public IRepository<Order> OrderRepository
    {
        get
        {
            if (orderRepository == null)
            {
                orderRepository = new OrdersRepository(context);
            }

            return orderRepository;
        }
    }

    private IRepository<Product> productRepository;
    public IRepository<Product> ProductRepository
    {
        get
        {
            if (productRepository == null)
            {
                productRepository = new ProductsRepository(context);
            }

            return productRepository;
        }
    }
    private IRepository<OrderDetail> orderDetailsRepository;
    public IRepository<OrderDetail> OrderDetailsRepository
    {
        get
        {
            if (orderDetailsRepository == null)
            {
                orderDetailsRepository = new OrderDetailsRepository(context);
            }

            return orderDetailsRepository;
        }
    }


    public void SaveChanges()
    {
        context.SaveChanges();
    }
}