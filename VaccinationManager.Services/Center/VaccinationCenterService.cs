using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Models.Center;
using VaccinationManager.Models.Personne;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Center
{
    public class VaccinationCenterService : BaseService, IService<VaccinationCenter>
    {
        public VaccinationCenterService(DataContext dc) : base(dc)
        {
        }

        public VaccinationCenter Delete(int id)
        {
            VaccinationCenter result = GetById(id);
            if(result != null)
            {
                _dc.vaccinationCenters.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<VaccinationCenter> GetAll()
        {
            return _dc.vaccinationCenters.ToList();


        }

        public IEnumerable<VaccinationCenter> GetFullAll()
        {
            List<VaccinationCenter> centerList = _dc.vaccinationCenters
                                                    .Include(cl => cl.Adress)
                                                    .Include(cl => cl.Manager).ThenInclude(m=>m.Staff).ThenInclude(s=>s.Person)                                                    
                                                    .ToList();

            return centerList.Select(e =>
                new VaccinationCenter
                {
                    Id = e.Id,
                    Name = e.Name,
                    AdressId = e.AdressId,
                    Adress = e.Adress,
                    ManagerId = e.ManagerId,
                    Manager = e.Manager
                }
                )
                    ;



        }


        public VaccinationCenter GetById(int id)
        {
                return _dc.vaccinationCenters
                        .Include(a=>a.Adress)
                        .Include(m=>m.Manager)
                        .SingleOrDefault(vc => vc.Id == id);
        }

        public VaccinationCenter Insert(VaccinationCenter entity)
        {
            EntityEntry<VaccinationCenter> result = _dc.vaccinationCenters.Add(entity);
            _dc.SaveChanges();
            return result.Entity;
        }

        public VaccinationCenter Update(VaccinationCenter entity)
        {
            VaccinationCenter result = GetById(entity.Id);

            if(result != null)
            {
                result.Name = entity.Name;
                result.AdressId = entity.AdressId;
                result.ManagerId = entity.ManagerId;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
