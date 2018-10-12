using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class AnneeScolaireRepository : BaseRepository<AnneeScolaire>
    {
        public AnneeScolaireRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override AnneeScolaire Get(int id, bool includeRelatedEntity = true)
        {
            var anneeScolaire = Context.AnneeScolaires.AsQueryable();
            if (includeRelatedEntity)
            {
                //anneeScolaire = anneeScolaire.Include(u => u.CreerPar).Include(u => u.Modifierpar);
            }

            return anneeScolaire.Where( a => a.Id == id).FirstOrDefault();
        }

        public override IList<AnneeScolaire> GetList()
        {
            return Context.AnneeScolaires.ToList();
        }
    }

    public class PeriodeRepository : BaseRepository<PeriodePersonnalisee>
    {
        public PeriodeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override PeriodePersonnalisee Get(int id, bool includeRelatedEntity = true)
        {
            var periode = Context.PeriodePersonnalisees.AsQueryable();
            return periode.Where(p => p.Id == id).FirstOrDefault();
        }

        public override IList<PeriodePersonnalisee> GetList()
        {
            return Context.PeriodePersonnalisees.Include(a=>a.AnneeScolaire).ToList();
        }
    }
}
