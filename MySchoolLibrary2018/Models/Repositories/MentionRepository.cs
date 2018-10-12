using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class MentionRepository : BaseRepository<Mention>
    {
        public MentionRepository(ApplicationDbContext context): base(context)
        {

        }

        public override Mention Get(int id, bool includeRelatedEntity = true)
        {
            var mentions = Context.Mentions.AsQueryable();
            return mentions.Where(m => m.Id == id).FirstOrDefault();
        }

        public override IList<Mention> GetList()
        {
            return Context.Mentions.ToList();

        }
    }
}
