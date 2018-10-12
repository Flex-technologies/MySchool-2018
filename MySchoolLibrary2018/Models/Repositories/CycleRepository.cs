using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class CycleRepository : BaseRepository<Cycle>
    {
        public CycleRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override Cycle Get(int id, bool includeRelatedEntity = true)
        {
            throw new NotImplementedException();
        }
        public override Cycle Get(string id)
        {
            var cycles = Context.Cycles.AsQueryable();
            return cycles.Where(c => c.Id == id).SingleOrDefault();
        }
        public override IList<Cycle> GetList()
        {
            return Context.Cycles.ToList();
        }
    }
}
