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
    public class OutLogService : BaseService, IService<OutLog>
    {
        public OutLogService(DataContext dc) : base(dc)
        {
        }

        public OutLog Delete(int id)
        {
            OutLog result = GetById(id);

            if(result != null)
            {
                _dc.OutLogs.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<OutLog> GetAll()
        {
            return _dc.OutLogs.ToList();
        }

        public OutLog GetById(int id)
        {
            return _dc.OutLogs.SingleOrDefault(ol => ol.Id == id);
        }

        public OutLog Insert(OutLog entity)
        {
            EntityEntry<OutLog> result = _dc.OutLogs.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public OutLog Update(OutLog entity)
        {
            OutLog result = GetById(entity.Id);

            if(result != null)
            {
                result.Id = entity.Id;
                result.OutDate = entity.OutDate;
                result.Quantity = entity.Quantity;
                result.VaccinLotId = entity.VaccinLotId;

                _dc.SaveChanges();
            }

            return result;
        }
    }
}
