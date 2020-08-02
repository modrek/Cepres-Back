using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CepresTask.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CepresTask.Dtos;

namespace CepresTask.Domain.Validations
{
    
    public class PatientValidator : AbstractValidator<PatientWriteDtoModel>
    {
        private readonly IEnumerable<PatientModel> _patients;
        private readonly CepresDBContext _context;

        public PatientValidator(CepresDBContext context)
        {
            _patients = context.Patients;
            RuleFor(x => x.PatientName).NotEmpty();
            RuleFor(x => x.OfficialID).NotEmpty().Must(IsNameUnique).WithMessage("Patient with this OfficialID is exists.");
            RuleFor(x => x.EmailAddress).EmailAddress();           
        }


        private bool IsNameUnique(PatientWriteDtoModel entity, Int64 newValue)
        {
            if (entity.PatientId != Guid.Empty) // means update record
                return true;

            return _patients.All(p =>
              p.Equals(entity) || p.OfficialID != newValue);
        }


    }
}
