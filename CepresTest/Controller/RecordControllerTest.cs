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
    public class RecordControllerTest : CepresDBContextTest
    {
        [Fact]
        public async Task AddRecord()
        {

            RecordRepository recordRepository = new RecordRepository(_context);

            RecordController ctrl = new RecordController(recordRepository);
            var actionResult =await ctrl.CreateRecord(new RecordWriteDtoModel
            {
                PatientId = Guid.Parse("7d950fc9-b874-41cb-85af-c2f99dd47343"),
                Bill = 15 / 57,
                Description = "No desc",
                DiseaseName = "Diabet",
                TimeOfEntry = DateTime.Now
            }) ;

            var okResult = actionResult as OkObjectResult;

            
            Assert.Equal(okResult.StatusCode,200);
        }

        [Fact]
        public async Task GetRecordCountFromRepository()
        {

            RecordRepository recordRepository = new RecordRepository(_context);

            var Result = recordRepository.GetCount();

            Assert.Equal(Result, 1);
        }

    }
}
