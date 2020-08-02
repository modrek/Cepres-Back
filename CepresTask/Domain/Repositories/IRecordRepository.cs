using CepresTask.Domain.Models;
using CepresTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CepresTask.Domain.Repositories
{
    public interface IRecordRepository : IRepository<RecordModel>
    {
        public IEnumerable<RecordModel> RecordList(GetListRequest request);
    }
}
