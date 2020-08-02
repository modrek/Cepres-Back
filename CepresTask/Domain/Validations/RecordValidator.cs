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
    
    public class RecordValidator : AbstractValidator<RecordWriteDtoModel>
    {
        public RecordValidator()
        {            
            RuleFor(x => x.PatientId).NotEmpty();
            RuleFor(x => x.DiseaseName).NotEmpty();
            
        }

    }
}
