using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class AutorisationRepository : BaseRepository<Autorisation>
    {
        public AutorisationRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Autorisation Get(int id, bool includeRelatedEntity = true)
        {
            throw new NotImplementedException();
        }

        public override Autorisation Get(string id)
        {
            var autorisation = Context.Autorisations.AsQueryable();
            return autorisation.Where(a => a.Id == id).FirstOrDefault();
        }

        public override IList<Autorisation> GetList()
        {
            return Context.Autorisations.ToList();
        }
    }
}
