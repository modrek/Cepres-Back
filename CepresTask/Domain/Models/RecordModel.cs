using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Domain.Models
{
    [Table("Records")]
    public class RecordModel
    {
        Guid _Id;

        [Key]
        public Guid RecordId
        {
            get
            {
                if (_Id == null)
                    return Guid.NewGuid();
                else
                    return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public Guid PatientId { get; set; }
        //[ForeignKey("PatientId")]
        virtual public PatientModel Patient { get; set; }
        public string DiseaseName { get; set; }

        public DateTime? TimeOfEntry { get; set; }

        public string Description   { get; set; }

        public decimal Bill  { get; set; }

    }

   
}
