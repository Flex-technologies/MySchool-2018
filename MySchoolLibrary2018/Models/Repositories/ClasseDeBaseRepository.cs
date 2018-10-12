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
            throw new NotImplementedException();
        }

        public override IList<ClasseDeBase> GetList()
        {
            return Context.ClasseDeBases.ToList();
        }
    }
}
