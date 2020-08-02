using CepresTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CepresTest.Infrastructures
{
    public class CepresDBContextTest : IDisposable
    {
        public CepresDBContext _context;

        public CepresDBContextTest()
        {
            var options = new DbContextOptionsBuilder<CepresDBContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            _context = new CepresDBContext(options);

            _context.Database.EnsureCreated();

            CepresDBContextInitializer.Initialize(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}
