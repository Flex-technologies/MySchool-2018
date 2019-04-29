using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class ClasseRepository : BaseRepository<Classe>
    {
        public ClasseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Classe Get(int id, bool includeRelatedEntity = true)
        {
            var classes = Context.Classes.AsQueryable();
            return classes.Where(c => c.Id == id).FirstOrDefault();
        }

        public override IList<Classe> GetList()
        {
            return Context.Classes.ToList();
        }

        public  IList<Classe> GetList(int EtablissementId)
        {
            return Context.Classes.Where(c => c.Etablissement.Id == EtablissementId).ToList();
        }
    }
}
