using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class InspectionRepository : BaseRepository<Inspection>
    {
        public InspectionRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Inspection Get(int id, bool includeRelatedEntity = true)
        {
            var inspections = Context.inspections.AsQueryable();
            return inspections.Where(i => i.Id == id).FirstOrDefault();
        }

        public override IList<Inspection> GetList()
        {
            return Context.inspections.ToList();
        }
    }
}
