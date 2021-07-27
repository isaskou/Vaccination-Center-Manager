using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.DAL.DataSet;
using VaccinationManager.DAL.EntitiesConfig;
using VaccinationManager.DAL.EntitiesConfig.Adresse;
using VaccinationManager.DAL.EntitiesConfig.Center;
using VaccinationManager.DAL.EntitiesConfig.Personne;
using VaccinationManager.DAL.EntitiesConfig.Rendez_vous;
using VaccinationManager.DAL.EntitiesConfig.Vaccin;
using VaccinationManager.Models;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Models.Center;
using VaccinationManager.Models.Personne;
using VaccinationManager.Models.RendezVous;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.DAL
{
    public class DataContext : DbContext
    {
        //private readonly string _cnstr;


        //public DataContext()
        //{
        //    _cnstr = @"server=LAPTOP-03RLPA2O;Database=VaccinationManager; Integrated Security=True;";
        //}

        //public DataContext(string cnstr)
        //{
        //    _cnstr = cnstr;
        //}


        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Adress> Adresses { get; set; }
        public DbSet<ScheduleCenter> scheduleCenters{get;set;}
        public DbSet<VaccinationCenter> vaccinationCenters { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<MedicalStaff> MedicalStaffs { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<FifteenHour> FifteenHours { get; set; }
        public DbSet<VaccinLot> VaccinLots { get; set; }

        public DbSet<VaccinProvider> VaccinProviders { get; set; }

        public DbSet<VaccinType> VaccinTypes { get; set; }

        public DbSet<Injection> Injections { get; set; }

        public DbSet<InLog> InLogs { get; set; }
        public DbSet<OutLog> OutLogs { get; set; }

        //Models ASP
        //public DbSet<CenterModel>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_cnstr);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AdressConfig());

            builder.ApplyConfiguration(new ScheduleCenterConfig());

            builder.ApplyConfiguration(new VaccinationCenterConfig());

            builder.ApplyConfiguration(new PersonConfig());

            builder.ApplyConfiguration(new StaffConfig());
            builder.ApplyConfiguration(new MedicalStaffConfig());

            builder.ApplyConfiguration(new PatientConfig());
            builder.ApplyConfiguration(new AppointmentConfig());
            builder.ApplyConfiguration(new FifteenHourConfig());
            builder.ApplyConfiguration(new VaccinLotConfig());

            builder.ApplyConfiguration(new VaccinProviderConfig());

            builder.ApplyConfiguration(new VaccinTypeConfig());

            builder.ApplyConfiguration(new InjectionConfig());
            builder.ApplyConfiguration(new InLogConfig());
            builder.ApplyConfiguration(new OutLogConfig());

            //DataSet
            builder.ApplyConfiguration(new DSVaccinationCenter());
            builder.ApplyConfiguration(new DSAdress());
            builder.ApplyConfiguration(new DSMedicalStaff());
            builder.ApplyConfiguration(new DSPerson());
            builder.ApplyConfiguration(new DSStaff());

        }
    }
}
