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
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
        }

        #region define Datasets

        //public DbSet<User> Users { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
       // public DbSet<MetaDataModel> MetaData { get; set; }
        public DbSet<RecordModel> Records { get; set; }

        #endregion define Datasets


    }
}
