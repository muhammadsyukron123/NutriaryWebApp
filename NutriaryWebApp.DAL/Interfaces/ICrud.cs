using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.Interfaces
{
    public interface ICrud<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
