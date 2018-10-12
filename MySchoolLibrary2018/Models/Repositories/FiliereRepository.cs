using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class FiliereRepository : BaseRepository<Filiere>
    {
        public FiliereRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Filiere Get(int id, bool includeRelatedEntity = true)
        {
            throw new NotImplementedException();
        }
        public override Filiere Get(string id)
        {
            var filieres = Context.Filieres.AsQueryable();
            return filieres.Where(f => f.Id == id).FirstOrDefault();
        }
        public override IList<Filiere> GetList()
        {
            return Context.Filieres.ToList();
        }
    }
}
