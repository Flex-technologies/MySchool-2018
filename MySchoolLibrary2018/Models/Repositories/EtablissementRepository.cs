using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class EtablissementRepository : BaseRepository<Etablissement>
    {
        public EtablissementRepository(ApplicationDbContext context): base(context)
        {

        }

        public override Etablissement Get(int id, bool includeRelatedEntity = true)
        {
            var etablissements = Context.Etablissements.AsQueryable();
            if (includeRelatedEntity)
            {
               //etablissements = etablissements.Include(u => u.CreerPar).Include(u => u.Modifierpar).Include(t => t.Type);
                
            }

            return etablissements.Where(e => e.Id == id).SingleOrDefault();
        }

        public override IList<Etablissement> GetList()
        {
            return Context.Etablissements.ToList();
        }
    }

    public class TypeEtablissementRepository : BaseRepository<TypeEtablissement>
    {
        public TypeEtablissementRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override TypeEtablissement Get(int id, bool includeRelatedEntity = true)
        {
            return Context.TypeEtablissements.Find(id);
        }

        public override TypeEtablissement Get(string id)
        {
            return Context.TypeEtablissements.Find(id);
        }

        public override IList<TypeEtablissement> GetList()
        {
            return Context.TypeEtablissements.ToList();
        }
    }
}
