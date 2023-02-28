using CinemaManagament.Repositories.Common;
using CinemaManagamentAppication.Models;
using System.Collections.Generic;


namespace CinemaManagament.Repositories
{
    public class HallRepository
    {
        public HallRepository()
        {
            _halls = new List<Hall>();
        }

        private List<Hall> _halls { get; set; }

        public void Create(Hall hall)
        {
            hall.Id = IdGenerator.GenerateId(_halls);
            _halls.Add(hall);
        }
    }
}
