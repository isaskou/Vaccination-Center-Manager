using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Models.Center;
using VaccinationManager.Services.Base;
using VaccinationManager.Services.Interfaces;

namespace VaccinationManager.Services
{
    public class VaccinationCenterService : BaseService, IService<VaccinationCenter>
    {
        public VaccinationCenterService(DataContext dc) : base(dc)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VaccinationCenter> GetAll()
        {
            return _dc.vaccinationCenters.ToList();
        }

        public VaccinationCenter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(VaccinationCenter entity)
        {
            throw new NotImplementedException();
        }

        public void Update(VaccinationCenter entity)
        {
            throw new NotImplementedException();
        }
    }
}
