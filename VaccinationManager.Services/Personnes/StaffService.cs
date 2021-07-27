using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Personne;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Personnes
{
    public class StaffService : BaseService, IService<Staff>
    {
        public StaffService(DataContext dc) : base(dc)
        {
        }

        public Staff Delete(int id)
        {
            Staff result = GetById(id);
            if(result != null)
            {
                _dc.Staffs.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Staff> GetAll()
        {
            return _dc.Staffs.ToList();
        }

        public Staff GetById(int id)
        {
            return _dc.Staffs
                .Include(s=>s.Person)
                .SingleOrDefault(s => s.Id == id);
        }

        public Staff Insert(Staff entity)
        {
            EntityEntry<Staff> result = _dc.Staffs.Add(entity);
            _dc.SaveChanges();
            return result.Entity;
        }

        public Staff Update(Staff entity)
        {
            Staff result = GetById(entity.Id);

            if(result != null)
            {
                result.Grade = entity.Grade;
                result.PersonId = entity.PersonId;

                _dc.SaveChanges();
            }

            return result;
        }
    }
}
