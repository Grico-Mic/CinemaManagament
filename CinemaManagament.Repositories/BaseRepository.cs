using CinemaManagament.Repositories.Common;
using CinemaManagamentAppication.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaManagament.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public BaseRepository()
        {
            Data = new List<T>();
        }
        protected List<T> Data { get; set; }

       

        public void Create(T entity)
        {
            entity.Id = GenerateId();
            Data.Add(entity);
        }

        public void Delete(T entity)
        {
            Data.Remove(entity);
        }

        public List<T> GetAll()
        {
            return Data;
        }

        public T GetById(int id)
        {
            return Data.FirstOrDefault(x => x.Id == id);
        }

        private int GenerateId() 
        {

            {
                var newId = 0;

                if (Data.Count > 0)
                {
                    newId = Data.Max(x => x.Id);

                }
                return newId + 1;
            }
        }
    }
}
