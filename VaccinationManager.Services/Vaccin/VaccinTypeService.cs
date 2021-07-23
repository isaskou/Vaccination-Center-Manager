using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Vaccin;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Vaccin
{
    public class VaccinTypeService : BaseService, IService<VaccinType>
    {
        public VaccinTypeService(DataContext dc) : base(dc)
        {
        }

        public VaccinType Delete(int id)
        {
            VaccinType result = GetById(id);
            if(result != null)
            {
                _dc.VaccinTypes.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<VaccinType> GetAll()
        {
            return _dc.VaccinTypes.ToList();
        }

        public VaccinType GetById(int id)
        {
            return _dc.VaccinTypes.SingleOrDefault(vt => vt.Id == id);
        }

        public VaccinType Insert(VaccinType entity)
        {
            EntityEntry<VaccinType> result = _dc.VaccinTypes.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public VaccinType Update(VaccinType entity)
        {
            VaccinType result = GetById(entity.Id);

            if(result != null)
            {
                result.Id = entity.Id;
                result.Name = entity.Name;

                _dc.SaveChanges();
            }
            return (result);
        }
    }
}
