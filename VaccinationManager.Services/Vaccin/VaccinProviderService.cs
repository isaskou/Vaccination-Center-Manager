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
    public class VaccinProviderService : BaseService, IService<VaccinProvider>
    {
        public VaccinProviderService(DataContext dc) : base(dc)
        {
        }

        public VaccinProvider Delete(int id)
        {
            VaccinProvider result = GetById(id);

            if(result != null) {
                _dc.VaccinProviders.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<VaccinProvider> GetAll()
        {
            return _dc.VaccinProviders.ToList();
        }

        public VaccinProvider GetById(int id)
        {
            return _dc.VaccinProviders.SingleOrDefault(vp => vp.Id == id);
        }

        public VaccinProvider Insert(VaccinProvider entity)
        {
            EntityEntry<VaccinProvider> result = _dc.VaccinProviders.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public VaccinProvider Update(VaccinProvider entity)
        {
            VaccinProvider result = GetById(entity.Id);

            if(result != null)
            {
                result.Name = entity.Name;
                result.AdressId = entity.AdressId;

                _dc.SaveChanges();

            }
            return result;

        }
    }
}
