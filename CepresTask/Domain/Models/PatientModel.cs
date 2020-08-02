using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Domain.Models
{
    [Table("Patients")]
    public class PatientModel
    {
        Guid _Id;

        [Key]
        public Guid PatientId
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

        [Display(Name = "Name of Patient")]
        public string PatientName { get; set; }

        public Int64 OfficialID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        [ForeignKey("PatientId")]
        public ICollection<MetaDataModel> MetaData { get; set; }

        [ForeignKey("PatientId")]
        public ICollection<RecordModel> Records { get; set; }




    }

    [Table("MetaData")]
    public class MetaDataModel
    {
        Guid _Id;

        [Key]
        public Guid Id
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
        //virtual public PatientModel Patient { get; set; }


        public string Key { get; set; }
        public string Value { get; set; }
    }
   
}
