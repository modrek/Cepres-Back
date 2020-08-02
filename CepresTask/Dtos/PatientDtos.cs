using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Dtos
{
    public class PatientReadDtoModel
    {
        public Guid PatientId { get; set; }

        public string PatientName { get; set; }

        public Int64 OfficialID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public ICollection<MetaDataDto> MetaData { get; set; }
    }
    public class PatienListReadDtoModel
    {
        public Int64 TotalRecord { get; set; }
        public IEnumerable<PatienListReadDtoItem> Items { get; set; }

    }
    public class PatienListReadDtoItem
    {
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? LastEntry { get; set; }
        public int MetaDataCount { get; set; }
    }
    public class PatientReportReadDtoModel
    {

        public string PatientName { get; set; }
        public int Age { get; set; }
        public decimal AvarageOfBill { get; set; }
        public decimal StdevOfBill { get; set; }
        public List<RecordReadDtoModel> FifthRecordEntry { get; set; }
        public List<PatientReadDtoModel> SimelarPatient { get; set; }
        public int? CriticalMonth { get; set; }
    }
    public class MetaReportReadDtoModel
    {
        public int Average { get; set; }
        public int Max { get; set; }
        public List<MetaDataReportDto> Top3Highestkeys { get; set; }
    }
    public class MetaDataDto
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }

    }
    public class MetaDataReportDto
    {
        public string Key { get; set; }
        public Int32 Count { get; set; }

    }
    public class PatientWriteDtoModel
    {
        public Guid PatientId { get; set; }

        [Required]
        public string PatientName { get; set; }

        public Int64 OfficialID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string EmailAddress { get; set; }
      
        public ICollection<MetaDataDto> MetaData { get; set; }

       
    }
}
