using Microsoft.EntityFrameworkCore;
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
    public class PatientService : BaseService, IService<Patient>
    {
        public PatientService(DataContext dc) : base(dc)
        {
        }

        public Patient Delete(int id)
        {
            Patient result = GetById(id);
            if(result != null)
            {
                _dc.Patients.Remove(result);

                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _dc.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _dc.Patients
                .Include(p=>p.Person)
                .SingleOrDefault(p => p.Id == id);
        }

        public Patient Insert(Patient entity)
        {
            EntityEntry<Patient> result = _dc.Patients.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public Patient Update(Patient entity)
        {
            Patient result = GetById(entity.Id);

            if(result != null)
            {
                result.NationalRegister = entity.NationalRegister;
                result.DateOfBirth = entity.DateOfBirth;
                result.MedicalIndication = entity.MedicalIndication;
                result.PersonId = entity.PersonId;
                result.AdressId = entity.AdressId;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
