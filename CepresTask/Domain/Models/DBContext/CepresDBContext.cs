using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Domain.Models
{
    public class CepresDBContext : DbContext
    {
        public CepresDBContext(DbContextOptions<CepresDBContext> options)
        : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region seed data
            Guid PatientId = Guid.NewGuid();
            List<MetaDataModel> metadata = new List<MetaDataModel>()
            {
                new MetaDataModel (){ Key = "Age", Value = "56" ,PatientId=PatientId,Id=Guid.NewGuid() },
                new MetaDataModel() { Key = "Diabetes", Value = "yes",PatientId=PatientId,Id=Guid.NewGuid() },
                new MetaDataModel() { Key = "city", Value = "Salfeet " ,PatientId=PatientId,Id=Guid.NewGuid()},
                new MetaDataModel() { Key = "heart", Value = "open surgery",PatientId=PatientId,Id=Guid.NewGuid() }
            };
            PatientModel patient1 = new PatientModel()
            {
                PatientId = PatientId,
                OfficialID = 1901,
                PatientName = "Ahmad",
                EmailAddress = "test@test.com",
            };


            PatientId = Guid.NewGuid();
            metadata.AddRange(new List<MetaDataModel>(){
                new MetaDataModel() { Key = "Age", Value = "35" ,PatientId=PatientId,Id=Guid.NewGuid()},
                new MetaDataModel() { Key = "city", Value = "Ramallah",PatientId=PatientId,Id=Guid.NewGuid() }
            });
            PatientModel patient2 = new PatientModel()
            {
                PatientId = PatientId,
                OfficialID = 1902,
                PatientName = "sami",
                EmailAddress = "test@test.com",
            };


            PatientId = Guid.NewGuid();
            metadata.AddRange(new List<MetaDataModel>(){
                new MetaDataModel() { Key = "Age", Value = "20" ,PatientId=PatientId,Id=Guid.NewGuid()},
                new MetaDataModel() { Key = "city", Value = "Jenin",PatientId=PatientId,Id=Guid.NewGuid() }
            });
            PatientModel patient3 = new PatientModel()
            {
                PatientId = PatientId,
                OfficialID = 1903,
                PatientName = "Mohammad",
                EmailAddress = "test@test.com",

            };


            PatientId = Guid.NewGuid();
            metadata.AddRange(new List<MetaDataModel>(){
                new MetaDataModel() { Key = "Age", Value = "60" ,PatientId=PatientId,Id=Guid.NewGuid()},
                new MetaDataModel() { Key = "Cancer", Value = "yes" ,PatientId=PatientId,Id=Guid.NewGuid()},
                new MetaDataModel() { Key = "Asthma", Value = "yes" ,PatientId=PatientId,Id=Guid.NewGuid()}
            });
            PatientModel patient4 = new PatientModel()
            {
                PatientId = PatientId,
                OfficialID = 1904,
                PatientName = "Jane",
                EmailAddress = "test@test.com",

            };

            modelBuilder.Entity<PatientModel>().HasData(patient1, patient2, patient3, patient4);
            modelBuilder.Entity<MetaDataModel>().HasData(metadata);

            #endregion
        }

        #region define Datasets

        //public DbSet<User> Users { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        // public DbSet<MetaDataModel> MetaData { get; set; }
        public DbSet<RecordModel> Records { get; set; }

        #endregion define Datasets


    }
}
