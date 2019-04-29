using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class TypeInspectionRepository : BaseRepository<TypeInspection>
    {
        public TypeInspectionRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override TypeInspection Get(int id, bool includeRelatedEntity = true)
        {
            var typeInspections = Context.TypeInspections.AsQueryable();
            return typeInspections.Where(t => t.Id == id).FirstOrDefault();
        }

        public override IList<TypeInspection> GetList()
        {
            return Context.TypeInspections.ToList();
        }
    }
}
