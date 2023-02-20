using System;


namespace CinemaManagamentAppication.Models
{
    public class Product : BaseEntity
    {
       
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Id}.{Name}.Quantity:{Quantity}.Price{Price}");
            
        }

    }
}
