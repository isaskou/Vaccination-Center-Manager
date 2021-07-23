using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services
{
    public class InjectionService : BaseService, IService<Injection>
    {
        public InjectionService(DataContext dc) : base(dc)
        {
        }

        public Injection Delete(int id)
        {
            Injection result = GetById(id);

            if(result != null)
            {
                _dc.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Injection> GetAll()
        {
            return _dc.Injections.ToList();
        }

        public Injection GetById(int id)
        {
            return _dc.Injections.SingleOrDefault(i => i.Id == id);
                }

        public Injection Insert(Injection entity)
        {
            EntityEntry<Injection> result = _dc.Injections.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public Injection Update(Injection entity)
        {
            Injection result = GetById(entity.Id);

            if (result != null)
            {
                result.Id = entity.Id;
                result.VaccinLotId = entity.VaccinLotId;
                result.MedicalStaffId = entity.MedicalStaffId;
                result.AppointmentId = entity.AppointmentId;

                _dc.SaveChanges();

            }
            return result;
        }
    }
}
