using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class ClasseDeBaseRepository : BaseRepository<ClasseDeBase>
    {
        public ClasseDeBaseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override ClasseDeBase Get(int id, bool includeRelatedEntity = true)
        {
            var classes = Context.ClasseDeBases.AsQueryable();
            return classes.Where(c => c.Id == id).FirstOrDefault();
        }

        public override IList<ClasseDeBase> GetList()
        {
            return Context.ClasseDeBases.ToList();
        }
    }
}
