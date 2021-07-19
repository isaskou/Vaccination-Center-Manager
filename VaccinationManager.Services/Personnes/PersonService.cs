using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Person;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Personnes
{
    public class PersonService : BaseService, IService<Person>
    {
        public PersonService(DataContext dc) : base(dc)
        {
        }

        public Person Delete(int id)
        {
            Person result = GetById(id);
            if(result != null)
            {
                _dc.People.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Person> GetAll()
        {
            return _dc.People.ToList();
        }

        public Person GetById(int id)
        {
            return _dc.People.SingleOrDefault(p=>p.Id == id);
        }

        public Person Insert(Person entity)
        {
            EntityEntry<Person> result = _dc.People.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public Person Update(Person entity)
        {
            Person result = GetById(entity.Id);

            if(result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.Tel = entity.Tel;
                result.Email = entity.Email;
                result.Password = entity.Password;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
