using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagamentAppication.Models
{
    public class Hall : BaseEntity
    {
        public string Name { get; set; }

        public int NumberOfSeads { get; set; }
        public int MovieId { get; set; }
    }
}
