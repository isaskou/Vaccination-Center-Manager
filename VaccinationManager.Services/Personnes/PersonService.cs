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
using VaccinationManager.Tools;
using VaccinationManager.Tools.SecurityTools;

namespace VaccinationManager.Services.Personnes
{
    public class PersonService : BaseService, IService<Person>
    {
        private Func<Person, Person> mapping =
            (pro) =>
            {
                if (pro is null) return null;
                return new Person
                {
                    Id = pro.Id,
                    FirstName = pro.FirstName,
                    LastName = pro.LastName,
                    Email = pro.Email,
                    Tel = pro.Tel,
                    Token = null,
                };
            };
        public PersonService(DataContext dc) : base(dc)
        {
        }

        public Person Check(string mail, string password)
        {
            Person profile = _dc.People.Where(p => p.Email == mail).SingleOrDefault();
            if (profile == null) return null;
            byte[] possiblePassword = PasswordHasher.Hashing(profile, password, pa => pa.Salt);
            if (possiblePassword.SequenceEqual(profile.Password)) return mapping(profile);
            return null;
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
            return _dc.People.Select(p=>mapping(p)).ToList();
        }

        public Person GetById(int id)
        {
            return mapping(_dc.People.SingleOrDefault(p=>p.Id == id));
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
                result.Token = entity.Token;
                _dc.SaveChanges();
            }
            return result;
        }
    }
}
