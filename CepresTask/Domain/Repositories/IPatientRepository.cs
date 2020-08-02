using CepresTask.Domain.Models;
using CepresTask.Domain.Repositories;
using CepresTask.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Domain.Repositories
{
    public interface IPatientRepository : IRepository<PatientModel>
    {
        public IEnumerable<PatientModel> PatientList(GetListRequest request);
        public PatientReportReadDtoModel PatientReport(Guid patientId);                
        public MetaReportReadDtoModel MetaReport();

        public PatientReadDtoModel GetById(Guid patientId);

    }
}
