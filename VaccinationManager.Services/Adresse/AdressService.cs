using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Adresse
{
    public class AdressService : BaseService, IService<Adress>
    {
        public AdressService(DataContext dc) : base(dc)
        {
        }

        public Adress Delete(int id)
        {
            Adress result = GetById(id);
            if(result != null)
            {
                _dc.Adresses.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Adress> GetAll()
        {
            return _dc.Adresses.ToList();
        }

        public Adress GetById(int id)
        {
            return _dc.Adresses.SingleOrDefault(a => a.Id == id);
        }

        public Adress Insert(Adress entity)
        {
           EntityEntry<Adress> result= _dc.Adresses.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public Adress Update(Adress entity)
        {
            Adress result = GetById(entity.Id);

            if(result != null)
            {
                result.Street = entity.Street;
                result.Number = entity.Number;
                result.PostalCode = entity.PostalCode;
                result.City = entity.City;
                result.District = entity.District;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
