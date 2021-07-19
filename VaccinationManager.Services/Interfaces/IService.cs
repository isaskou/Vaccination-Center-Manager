using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Services.Interfaces
{
    public interface IService<T> 
        where T:class
    {
        T Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T entity);
        T Update(T entity);

    }
}
