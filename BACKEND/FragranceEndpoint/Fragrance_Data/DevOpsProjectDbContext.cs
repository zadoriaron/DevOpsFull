using Fragrance_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragrance_Data
{
    public class DevOpsProjectDbContext:DbContext
    {
        public DbSet<FragranceModel> Fragrances { get; set; }

        public DevOpsProjectDbContext(DbContextOptions<DevOpsProjectDbContext> ctx) : base(ctx)
        {

        }
    }
}
