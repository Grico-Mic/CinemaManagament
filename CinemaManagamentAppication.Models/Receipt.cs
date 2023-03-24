

using System;
using System.Collections.Generic;

namespace CinemaManagamentAppication.Models
{
    public  class Receipt : BaseEntity
    {
        public Receipt()
        {
            DateCreated = DateTime.Now;
        }
        public List<Product> Products { get; set; }
        public int TicketQuantity { get; set; }
        public string HallName { get; set; }
        public string MovieTitle { get; set; }
        public decimal PricePerTicket { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
