using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);

        void Delete(string id);

        T Update(T entity);

        T GetById(string id);

        IList<T> GetAll();

    }
}
