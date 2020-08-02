using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CepresTask.Domain.Models;
using CepresTask.Domain.Repositories;
using CepresTask.Dtos;
using CepresTask.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CepresTask.Domain.Repositories
{
    public class PatientRepository : Repository<PatientModel>, IPatientRepository
    {
        private CepresDBContext _context;

        public PatientRepository(CepresDBContext context) : base(context)
        {
            _context = context;
        }

        public PatientReadDtoModel GetById(Guid patientId)
        {
           var entity =_context.Patients.Include(meta=>meta.MetaData).FirstOrDefault(x=>x.PatientId==patientId);
            PatientReadDtoModel result = new PatientReadDtoModel
            {
                DateOfBirth = Convert.ToDateTime((entity.DateOfBirth?.ToString("yyyy/MM/dd"))),
                EmailAddress = entity.EmailAddress,
                MetaData = entity.MetaData.Select(x=> new MetaDataDto { Key=x.Key,Value=x.Value}).ToList(),
                OfficialID = entity.OfficialID,
                PatientId = entity.PatientId,
                PatientName = entity.PatientName
            };
            return result;
           
        }

        public MetaReportReadDtoModel MetaReport()
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"select avg(cnt) Average , max(cnt) Max from (
                                            select count(*) cnt ,p.PatientId from Patients p 
                                            join metadata m on p.PatientId=m.PatientId
                                            group by p.PatientId
                                            ) as tmp

                                            select top 3 [Key] [Key] ,count(*) [Count]  from MetaData 
                                            group by [key] order by count(*) desc";
                string connetionString = command.Connection.ConnectionString;
                var adapter = new SqlDataAdapter(command.CommandText, connetionString);
                var ds = new DataSet();
                adapter.Fill(ds);
                DataTable dtAverageAndMax = ds.Tables[0];
                DataTable dtTop3MetaData = ds.Tables[1];

                var result = ExtensionMethods.ConvertToList<MetaReportReadDtoModel>(dtAverageAndMax);
                var resultTop3 = ExtensionMethods.ConvertToList<MetaDataReportDto>(dtTop3MetaData);

                result[0].Top3Highestkeys = resultTop3;
                return result[0];
            }

        }

        public IEnumerable<PatientModel> PatientList(GetListRequest request)
        {

            IEnumerable<PatientModel> result = _context.Set<PatientModel>()
                .Include(patient => patient.MetaData)
                .Include(patient => patient.Records);
            return Sort(result, request.Sort, request.SortDirection)
                .Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);


        }

        public PatientReportReadDtoModel PatientReport(Guid patientId)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @$"select p.PatientId,p.PatientName,datediff(YEAR, p.DateOfBirth,getdate()) Age,
                                        cast(AVG(r.Bill) as decimal(9,2)) AvarageOfBill,cast(STDEV(r.Bill)  
                                        as decimal(9,2)) StdevOfBill
                                        from Patients p 
                                        join Records r on p.PatientId=r.PatientId
                                        and p.[PatientId]='{patientId}'
                                        group by p.PatientId,p.PatientName,p.DateOfBirth

                                        select top 1 MONTH( TimeOfEntry )CriticalMonth from Records
                                                                                where PatientId='{patientId}'
                                                                                group by PatientId,MONTH( TimeOfEntry) 
                                                                                order by count(*) desc

                                        select top 5 RecordId, PatientId, DiseaseName,TimeOfEntry,description,bill from Records
                                        where PatientId='{patientId}' order by TimeOfEntry

                                        select r.PatientId ,min(patientName)patientName,min(p.OfficialID)OfficialID,min(p.EmailAddress)
                                        EmailAddress from Records  r
                                        join Patients p on r.PatientId=p.PatientId
                                        where DiseaseName 
                                        in (select distinct DiseaseName from Records where PatientId='{patientId}')
                                        and r.PatientId <>'{patientId}'
                                        group by r.PatientId having count(*)>=1";
                string connetionString = command.Connection.ConnectionString;

                var adapter = new SqlDataAdapter(command.CommandText, connetionString);
                var ds = new DataSet();
                try
                {
                    adapter.Fill(ds);
                }
                catch (Exception eeee)
                {

                    throw;
                }
                DataTable dtAverageAndMax = ds.Tables[0];
                DataTable dtCriticalMonth = ds.Tables[1];
                DataTable dtFifthRecordEntry = ds.Tables[2];
                DataTable dtSimelarPatient = ds.Tables[3];

                var result = ExtensionMethods.ConvertToList<PatientReportReadDtoModel>(dtAverageAndMax);
                if (result.Count == 0)
                    return null;
                result[0].CriticalMonth = Convert.ToInt32(dtCriticalMonth.Rows[0][0].ToString());
                result[0].FifthRecordEntry = ExtensionMethods.ConvertToList<RecordReadDtoModel>(dtFifthRecordEntry);
                result[0].SimelarPatient = ExtensionMethods.ConvertToList<PatientReadDtoModel>(dtSimelarPatient);
                return result[0];
            }


        }


    }
   
}
