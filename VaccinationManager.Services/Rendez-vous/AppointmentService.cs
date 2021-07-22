using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.RendezVous;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Rendez_vous
{
    public class AppointmentService : BaseService, IService<Appointment>
    {
        public AppointmentService(DataContext dc) : base(dc)
        {
        }

        public Appointment Delete(int id)
        {
            Appointment result = GetById(id);
            if(result != null)
            {
                _dc.Appointments.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _dc.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            return _dc.Appointments.SingleOrDefault(a => a.Id==id);
        }

        public Appointment Insert(Appointment entity)
        {
            EntityEntry<Appointment> result = _dc.Appointments.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public Appointment Update(Appointment entity)
        {
            Appointment result = GetById(entity.Id);

            if(result != null)
            {
                result.Date = entity.Date;
                result.FifteenHourId = entity.FifteenHourId;
                result.PatientId = entity.PatientId;
                result.VaccinTypeId = entity.VaccinTypeId;
                result.CenterId = entity.CenterId;
                result.InjectionId = entity.InjectionId;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
