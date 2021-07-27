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
    public class MedicalStaffService : BaseService, IService<MedicalStaff>
    {
        public MedicalStaffService(DataContext dc) : base(dc)
        {
        }

        public MedicalStaff Delete(int id)
        {
            MedicalStaff result = GetById(id);
            if(result != null)
            {
                _dc.MedicalStaffs.Remove(result);

                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<MedicalStaff> GetAll()
        {
            return _dc.MedicalStaffs.ToList();
        }

        public MedicalStaff GetById(int id)
        {
            return _dc.MedicalStaffs
                .Include(ms => ms.Staff)
                .SingleOrDefault(ms => ms.Id == id);
        }

        public MedicalStaff Insert(MedicalStaff entity)
        {
            EntityEntry<MedicalStaff> result = _dc.MedicalStaffs.Add(entity);

            _dc.SaveChanges();
            return result.Entity;
        }

        public MedicalStaff Update(MedicalStaff entity)
        {
            MedicalStaff result = GetById(entity.Id);

            if(result != null)
            {
                result.InamiCode = entity.InamiCode;
                result.StaffId = entity.StaffId;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
