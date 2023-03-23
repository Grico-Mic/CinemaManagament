
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
            Path = $"..\\..\\..\\..\\CinemaManagament.Repositories\\DB\\ { fileName}";
            
            if (!File.Exists(Path))
            {
               
                File.WriteAllText(Path, "[]");
            }
            var result =  File.ReadAllText(Path);
            var deserilizedList = JsonConvert.DeserializeObject<List<T>>(result);
            Data = deserilizedList;
        }
        protected List<T> Data { get; set; }
        protected string Path { get; set; }

       
        public void SaveChanges()  
        {
            var seriliazed = JsonConvert.SerializeObject(Data);
            File.WriteAllText(Path, seriliazed);
        }
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
