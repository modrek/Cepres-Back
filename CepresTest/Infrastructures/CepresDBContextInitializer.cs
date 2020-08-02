using CepresTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CepresTest.Infrastructures
{
    public class CepresDBContextInitializer
    {
        public static void Initialize(CepresDBContext context)
        {
            if (context.Patients.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(CepresDBContext context)
        {
            var Patients = new[]
            {
                new PatientModel {
                    PatientId=Guid.Parse("6ee3bcef-fafb-41c4-a400-464f3a91973e"),
                    PatientName = "Mohamamd Modrek",
                    EmailAddress = "m_modrek@yahoo.com",
                    OfficialID= 1286015928,
                    DateOfBirth=DateTime.Now,
                    MetaData= new List<MetaDataModel>{
                        new MetaDataModel {Key="Diabet",Value="No" },
                        new MetaDataModel { Key="Blood",Value="O+" }
                        }
                },
                new PatientModel {
                    PatientId=Guid.Parse("7d950fc9-b874-41cb-85af-c2f99dd47343"),
                    PatientName = "Ali Modrek",
                    EmailAddress = "a_modrek@yahoo.com",
                    OfficialID= 1286015929,
                    DateOfBirth=DateTime.Now,
                    MetaData= new List<MetaDataModel>{
                        new MetaDataModel {Key="Diabet",Value="Yes" },
                        new MetaDataModel { Key="Blood",Value="B-" }
                    }
                },

            };

            context.Patients.AddRange(Patients);
            RecordModel record = new RecordModel()
            {
                PatientId = Guid.Parse("7d950fc9-b874-41cb-85af-c2f99dd47343"),
                Bill = 15/57,
                Description = "No desc",
                DiseaseName = "Diabet",
                TimeOfEntry=DateTime.Now

            };
            context.Records.Add(record);
            context.SaveChanges();
        }
    }
}
