using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CepresTask.Domain.Models;
using CepresTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CepresTask.Domain.Repositories
{
    public class RecordRepository : Repository<RecordModel> , IRecordRepository
    {
        private CepresDBContext _context;

        public RecordRepository(CepresDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<RecordModel> RecordList(GetListRequest request)
        {          
            IEnumerable<RecordModel> result = _context.Records.Include(record => record.Patient);
             
            return Sort(result, request.Sort, request.SortDirection)
                .Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);


        }

    }
}
