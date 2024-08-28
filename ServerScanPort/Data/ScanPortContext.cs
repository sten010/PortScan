using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ServerScanPort.Data
{
    public class ScanPortContext : DbContext
    {
        public DbSet<Scaning> Scanings { get; set; } = null!;
        public ScanPortContext(DbContextOptions<ScanPortContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        
    }
}
