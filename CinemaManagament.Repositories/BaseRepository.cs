
using CinemaManagamentAppication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CinemaManagament.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public BaseRepository(string fileName)
        {
            var path = $"..\\..\\..\\..\\CinemaManagament.Repositories\\DB\\ { fileName}";
            if (!File.Exists(path))
            {
               
                File.WriteAllText(path, "[]");
            }
            var result =  File.ReadAllText(path);
            var deserilizedList = JsonConvert.DeserializeObject<List<T>>(result);
            Data = deserilizedList;
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

        public T GetByFirstOrDefault(Func<T, bool> predicate)
        {
            return Data.FirstOrDefault(predicate);
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
