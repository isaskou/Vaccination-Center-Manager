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
    public class InLogService : BaseService, IService<InLog>
    {
        public InLogService(DataContext dc) : base(dc)
        {
        }

        public InLog Delete(int id)
        {
            InLog result = GetById(id);
            if(result != null)
            {
                _dc.InLogs.Remove(result);
                _dc.SaveChanges();
            }

            return result;
        }

        public IEnumerable<InLog> GetAll()
        {
            return _dc.InLogs.ToList();
        }

        public InLog GetById(int id)
        {
            return _dc.InLogs.SingleOrDefault(il => il.Id == id);

        }

        public InLog Insert(InLog entity)
        {
            EntityEntry<InLog> result = _dc.InLogs.Add(entity);
            _dc.SaveChanges();

            return result.Entity;

        }

        public InLog Update(InLog entity)
        {
            InLog result = GetById(entity.Id);

            if(result != null)
            {
                result.Id = entity.Id;
                result.InDate = entity.InDate;
                result.Quantity = entity.Quantity;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
