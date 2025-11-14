using Fragrance_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragrance_Data
{
    public class FragranceRepository
    {
        DevOpsProjectDbContext ctx;

        public FragranceRepository(DevOpsProjectDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(FragranceModel fragrance)
        {
            ctx.Fragrances.Add(fragrance);
            ctx.SaveChanges();
        }

        public IQueryable<FragranceModel> GetAll()
        {
            return ctx.Fragrances;
        }

        public void Delete(string id)
        {
            FragranceModel fragrance = FindById(id);

            if (fragrance != null)
            {
                ctx.Fragrances.Remove(fragrance);
                ctx.SaveChanges();
            }
        }

        public FragranceModel FindById(string id)
        {
            return ctx.Fragrances.FirstOrDefault(f => f.Id == id);
        }
    }
}
