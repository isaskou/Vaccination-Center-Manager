using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Center;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services.Center
{
    public class ScheduleCenterService : BaseService, IService<ScheduleCenter>
    {
        public ScheduleCenterService(DataContext dc) : base(dc)
        {
        }

        public ScheduleCenter Delete(int id)
        {
            ScheduleCenter result = GetById(id);
            if(result != null)
            {
                _dc.scheduleCenters.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ScheduleCenter> GetAll()
        {
            return _dc.scheduleCenters.ToList();
        }

        public ScheduleCenter GetById(int id)
        {
            return _dc.scheduleCenters.SingleOrDefault(sc => sc.Id == id);
        }

        public ScheduleCenter Insert(ScheduleCenter entity)
        {
            EntityEntry<ScheduleCenter> result = _dc.scheduleCenters.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public ScheduleCenter Update(ScheduleCenter entity)
        {
            ScheduleCenter result = GetById(entity.Id);

            if(result != null)
            {
                result.Day = entity.Day;
                result.OpenHour = entity.OpenHour;
                result.CloseHour = entity.CloseHour;
                result.CenterId = entity.CenterId;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}

