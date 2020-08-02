using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CepresTask.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    //[Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {

            var entity = _patientRepository.Get(id);
            if (entity == null)
                return NotFound();
            _patientRepository.Remove(entity);

            if (_patientRepository.SaveChanges())
                return Ok(new { message = "Patient deleted successfully." });

            return BadRequest();

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {

            var entity = _patientRepository.GetById(id);
            if (entity == null)
                return NotFound();            

            return Ok(entity);

        }

        [HttpGet()]
        public async Task<ActionResult<PatienListReadDtoModel>> GetPatientList([FromQuery] GetListRequest request)
        {
            Int64 TotalRecord = _patientRepository.GetCount();
            // we can use auto mapper to map internal model to dto
            PatienListReadDtoModel result = new PatienListReadDtoModel()
            {
                TotalRecord = TotalRecord,
                Items = _patientRepository.PatientList(request).Select(x => new PatienListReadDtoItem
                {
                    DateOfBirth = Convert.ToDateTime((x.DateOfBirth?.ToString("yyyy/MM/dd"))),
                    PatientId = x.PatientId,
                    PatientName = x.PatientName,
                    MetaDataCount = x.MetaData.Count(),
                    LastEntry = x.Records.OrderByDescending(z => z.TimeOfEntry).FirstOrDefault()?.TimeOfEntry,
                })                
            };

            if (TotalRecord == 0)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("MetaReport")]
        public async Task<IActionResult> MetaReport()
        {
            var result = _patientRepository.MetaReport();
            if (result == null)
                return NotFound();

            return Ok(_patientRepository.MetaReport());

        }

        [HttpGet("PatientReport/{id}")]
        public async Task<IActionResult> PatientReport(Guid id)
        {
            var result = _patientRepository.PatientReport(id);

            if (result == null)
                return NotFound();

            return Ok(_patientRepository.PatientReport(id));

        }

        
        [HttpPut]        
        public async Task<IActionResult> UpdatePatient(PatientWriteDtoModel model)
        {
            // map Dto model to Internal Model  , We can Use auto mapper packeges            

            var entity = _patientRepository.Get(model.PatientId);

            if (entity == null)
                return NotFound();


            
            entity.DateOfBirth = model.DateOfBirth;
            entity.EmailAddress = model.EmailAddress;
            entity.MetaData = model.MetaData.Select(x => new MetaDataModel { Key = x.Key, Value = x.Value }).ToList();
            entity.PatientName = model.PatientName;
            entity.OfficialID = model.OfficialID;
            

            _patientRepository.Update(entity);

            if (_patientRepository.SaveChanges())
                return Ok(new { message = "Patient updated successfully." });

            return BadRequest();


        }
        
        [HttpPost]        
        public async Task<IActionResult> CreatePatient(PatientWriteDtoModel model)
        {
            // we can use auto mapper to map internal model to dto
            PatientModel entity = new PatientModel
            {
                DateOfBirth = model.DateOfBirth,
                EmailAddress= model.EmailAddress,
                MetaData= model.MetaData.Select(x=> new MetaDataModel { Key=x.Key,Value=x.Value}).ToList(),
                PatientName= model.PatientName,
                OfficialID= model.OfficialID
            };
            _patientRepository.Add(entity);
            if (_patientRepository.SaveChanges())
                return Ok(new { message = "Patient added successfully." });

            return BadRequest();


        }


    }
}
