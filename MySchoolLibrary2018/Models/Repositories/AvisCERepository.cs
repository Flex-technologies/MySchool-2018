using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class AvisCERepository : BaseRepository<AvisCE>
    {
        public AvisCERepository(ApplicationDbContext context) : base(context)
        {

        }

        public override AvisCE Get(int id, bool includeRelatedEntity = true)
        {
            var avis = Context.AvisCEs.AsQueryable();
            return avis.Where(a => a.Id == id).FirstOrDefault();
        }

        public override IList<AvisCE> GetList()
        {
            return Context.AvisCEs.ToList();
        }
    }
}
