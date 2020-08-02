using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Dtos
{
    public class RecordReadDtoModel
    {
        public Guid RecordId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        public string DiseaseName { get; set; }

        public DateTime? TimeOfEntry { get; set; }

        public string Description { get; set; }

        public decimal Bill { get; set; }
    }
    public class RecordListReadDtoModel
    {
        public Int64 TotalRecord { get; set; }

        public IEnumerable<RecordListReadDtoItem> Items { get; set; }
    }
    public class RecordListReadDtoItem
    {

        public Guid RecordId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        public string DiseaseName { get; set; }

        public DateTime? TimeOfEntry { get; set; }

        public string Description { get; set; }

        public decimal Bill { get; set; }
    }
    public class RecordWriteDtoModel
    {
        public Guid RecordId { get; set; }
        public Guid PatientId { get; set; }

        [Required]
        public string DiseaseName { get; set; }

        public DateTime? TimeOfEntry { get; set; }

        public string Description { get; set; }

        public decimal Bill { get; set; }
    }

}

