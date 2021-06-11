using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaCidenet.Models;

namespace PruebaCidenet.Data
{
    public class PruebaCidenetContext : DbContext
    {
        public PruebaCidenetContext (DbContextOptions<PruebaCidenetContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaCidenet.Models.Empleado> Empleado { get; set; }
    }
}
