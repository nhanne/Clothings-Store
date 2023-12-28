using Clothings_Store.Data;
using Clothings_Store.Interface;
using Clothings_Store.Models.Database;
using Clothings_Store.Models.Others;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Clothings_Store.Services;
public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICartService _cartService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICustomSessionService<string> _session;

    public OrderService(
        IUnitOfWork unitOfWork,
        ICartService cartService,
        IHttpContextAccessor httpContextAccessor,
        ICustomSessionService<string> session)
    {
        _unitOfWork = unitOfWork;
        _cartService = cartService;
        _httpContextAccessor = httpContextAccessor;
        _session = session;
        Console.Write("Đã tạo một instance mới");
    }
    public async Task PlaceOrder()
    {
        Order order = new Order();
        await orderInfo(order);
        await orderDetail(order.Id);
        _unitOfWork.SaveChanges();
    }
    private async Task orderInfo(Order order)
    {
        var listSession = _session.GetSession("order");
        var orderInfo = JsonConvert.DeserializeObject<OrderInfoSession>(listSession[0]);
        if (orderInfo == null || listSession.Count == 0) return;

        await Data(order, orderInfo);
        _unitOfWork.OrderRepository.Create(order);
    }
    public async Task Data(Order order, OrderInfoSession Model)
    {
        await orderInfo(order, Model);
        Task<double> amountTask = Amount(Model);
        await Task.WhenAll(amountTask);
        order.TotalPrice = amountTask.Result;
    }
    private async Task orderInfo(Order order, OrderInfoSession Model)
    {
        await Task.Run(() =>
        {
            var httpContext = _httpContextAccessor.HttpContext!;
            if (httpContext.User.Identity!.IsAuthenticated)
            {
                string userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                order.UserId = userId;
            }
            order.Id = Model.Id;
            order.OrdTime = Model.Time;
            order.DeliTime = Model.DeliveryTime;
            order.Status = Model.Status;
            order.PaymentId = Model.PaymentId;
            order.Address = Model.Address;
            order.Note = Model.Note;
            order.TotalQuantity = _cartService.TotalItems();
        });
    }


    private async Task<double> Amount(OrderInfoSession Model)
    {
        return await Task.Run(() =>
        {
            var codeKM = _unitOfWork.context.Promotions.SingleOrDefault(m =>
                m.PromotionName == Model.DiscountCode && m.EndDate > DateTime.UtcNow);
            double percent = (codeKM != null) ? (double)codeKM.DiscountPercentage : 100;

            IBillingStrategy normalPrice = new NormalStrategy();
            var CustomerBill = new CustomerBill(normalPrice);
            return CustomerBill.LastPrice(_cartService.TotalPrice(), percent);
        });
    }

    private async Task orderDetail(string orderId)
    {
        await Task.Run(() =>
        {
            var cartItems = _cartService.GetCart().ToList();
            foreach (var item in cartItems)
            {
                OrderDetail model = new OrderDetail
                {
                    OrderId = orderId,
                    StockId = item.IdCart,
                    Quantity = item.quantity,
                    UnitPrice = item.unitPrice
                };
                _unitOfWork.OrderDetailsRepository.Create(model);
                Console.WriteLine(model);
            }
        });
    }
}
