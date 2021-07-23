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
    public class VaccinLotService : BaseService, IService<VaccinLot>
    {
        public VaccinLotService(DataContext dc) : base(dc)
        {
        }

        public VaccinLot Delete(int id)
        {
            VaccinLot result = GetById(id);
            if(result != null)
            {
                _dc.VaccinLots.Remove(result);
                _dc.SaveChanges();
            }
            return result;
        }

        public IEnumerable<VaccinLot> GetAll()
        {
            return _dc.VaccinLots.ToList();
        }

        public VaccinLot GetById(int id)
        {
            return _dc.VaccinLots.SingleOrDefault(vl => vl.Id == id);
        }

        public VaccinLot Insert(VaccinLot entity)
        {
            EntityEntry<VaccinLot> result = _dc.VaccinLots.Add(entity);
            _dc.SaveChanges();

            return result.Entity;
        }

        public VaccinLot Update(VaccinLot entity)
        {
            VaccinLot result = GetById(entity.Id);

            if(result != null)
            {
                result.VaccinTypeId = entity.VaccinTypeId;
                result.ProviderId = entity.ProviderId;
                result.InLogId = entity.InLogId;
                result.CenterId = entity.CenterId;

                _dc.SaveChanges();
            }
            return result;
        }
    }
}
