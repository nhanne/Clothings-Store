using Clothings_Store.Data;
using Clothings_Store.Models.Database;

namespace Clothings_Store.Models.Others
{
    public class OrderInfoSession
    {
        DateTime Now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        public string Id { get; set; } = Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks.ToString();
        public string Address { get; set; }
        public DateTime Time
        {
            get => Now;
        }
        public DateTime DeliveryTime 
        { 
            get => Now.AddDays(3); 
        } 
        public double Amount { get; set; } = 0;
        public string DiscountCode { get; set; } = "";
        public int PaymentId { get; set; }
        public string Note { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; } = "Chờ xác nhận";
    }
}
