using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CepresTask.Domain.Models;
using CepresTask.Domain.Repositories;
using CepresTask.Dtos;
using CepresTask.Helper;
using CepresTask.Logger;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CepresTask.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    //[Authorize]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;

        public RecordController(IRecordRepository recordRepository)
        {

            _recordRepository = recordRepository;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(Guid id)
        {
            var entity = _recordRepository.Get(id);

            if (entity == null)
                return NotFound();

            _recordRepository.Remove(entity);

            if (_recordRepository.SaveChanges())
                return Ok(new { message = "Record deleted successfully." });

            return BadRequest();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(Guid id)
        {
            var entity = _recordRepository.Get(id);
            if (entity == null)
                return NotFound();

            RecordReadDtoModel result = new RecordReadDtoModel
            {
                RecordId = entity.RecordId,
                Bill = entity.Bill,
                Description = entity.Description,
                DiseaseName = entity.DiseaseName,
                PatientId = entity.PatientId,
                // TODO
                PatientName = "",
                TimeOfEntry = entity.TimeOfEntry
            };

            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult<RecordListReadDtoModel>> GetRecordList([FromQuery] GetListRequest request)
        {

            Int64 TotalRecord = _recordRepository.GetCount();

            // we can use auto mapper to map internal model to dto
            RecordListReadDtoModel result = new RecordListReadDtoModel()
            {
                TotalRecord = TotalRecord,
                Items = _recordRepository.RecordList(request).Select(x => new RecordListReadDtoItem
                {
                    RecordId = x.RecordId,
                    TimeOfEntry = x.TimeOfEntry,
                    Bill = x.Bill,
                    Description = x.Description,
                    DiseaseName = x.DiseaseName,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.PatientName
                })
            };

            if (result.Items.Count() == 0)
                return NotFound();

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateRecord(RecordWriteDtoModel model)
        {
            // we can use auto mapper to map internal model to dto
            var entity = _recordRepository.Get(model.RecordId);

            if (entity == null)
                return NotFound();


            entity.Bill = model.Bill;
            entity.Description = model.Description;
            entity.DiseaseName = model.DiseaseName;
            entity.PatientId = model.PatientId;
            entity.TimeOfEntry = model.TimeOfEntry;

            _recordRepository.Update(entity);

            if (_recordRepository.SaveChanges())
                return Ok(new { message = "Record updated successfully." });

            return BadRequest();

        }


        [HttpPost]
        public async Task<IActionResult> CreateRecord(RecordWriteDtoModel model)
        {
            // map Dto model to Internal Model  , We can Use auto mapper packeges
            RecordModel entity = new RecordModel
            {
                Bill = model.Bill,
                Description = model.Description,
                DiseaseName = model.DiseaseName,
                PatientId = model.PatientId,
                TimeOfEntry = model.TimeOfEntry
            };

            _recordRepository.Add(entity);
            if (_recordRepository.SaveChanges())
                return Ok(new { message = "Record added successfully." });

            return BadRequest();
        }


    }
}
