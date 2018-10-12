using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class NiveauRepository : BaseRepository<Niveau>
    {
        public NiveauRepository(ApplicationDbContext context):base(context)
        {

        }
        //public  Niveau Get(string id)
        //{
        //    var niveaux = Context.Niveaux.AsQueryable();
        //    return niveaux.Where(n => n.Id == id).SingleOrDefault();
           
        //}

        public override Niveau Get(int id, bool includeRelatedEntity = true)
        {
            throw new NotImplementedException();
        }

        public override IList<Niveau> GetList()
        {
            return Context.Niveaux.ToList();
        }
    }
}
