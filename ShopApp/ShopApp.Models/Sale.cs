using System;

namespace ShopApp.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SalerId { get; set; }
        public int Sum { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
