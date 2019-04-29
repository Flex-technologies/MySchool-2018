using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class MinistereRepository : BaseRepository<Ministere>
    {
        public MinistereRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Ministere Get(int id, bool includeRelatedEntity = true)
        {
            var ministeres = Context.Ministeres.AsQueryable();
            return ministeres.Where(m => m.Id == id).FirstOrDefault();
        }

        public override IList<Ministere> GetList()
        {
            return Context.Ministeres.ToList();
        }
    }
}