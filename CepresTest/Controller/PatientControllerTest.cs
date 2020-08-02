using CepresTask.Controllers;
using CepresTask.Domain.Models;
using CepresTask.Domain.Repositories;
using CepresTask.Dtos;
using CepresTest.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CepresTest.Controller
{
    public class PatientControllerTest : CepresDBContextTest
    {
        [Fact]
        public async Task AddPatient()
        {

            PatientRepository patientRepository = new PatientRepository(_context);

            PatientController ctrl = new PatientController(patientRepository);
            var actionResult =await ctrl.CreatePatient(new PatientWriteDtoModel
            {
                PatientName = "Alireza Modrek",
                EmailAddress = "a_mossdrek@yahoo.com",
                OfficialID = 1286015930,
                DateOfBirth = DateTime.Now,
                MetaData = new List<MetaDataDto>{
                        new MetaDataDto {Key="Diabet",Value="No" },
                        new MetaDataDto { Key="Blood",Value="B+" }
                }
            }) ;

            var okResult = actionResult as OkObjectResult;

            
            Assert.Equal(okResult.StatusCode,200);
        }

        [Fact]
        public async Task GetPatientCountFromRepository()
        {

            PatientRepository patientRepository = new PatientRepository(_context);

            

            var Result = patientRepository.GetCount();


            Assert.Equal(Result, 2);
        }

    }
}
