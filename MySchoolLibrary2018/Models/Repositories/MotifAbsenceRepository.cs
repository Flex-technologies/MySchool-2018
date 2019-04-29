using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.Repositories
{
    public class MotifAbsenceRepository : BaseRepository<MotifAbsence>
    {
        public MotifAbsenceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override MotifAbsence Get(int id, bool includeRelatedEntity = true)
        {
            throw new NotImplementedException();
        }

        public override MotifAbsence Get(string id)
        {
            return base.Get(id);
        }

        public override IList<MotifAbsence> GetList()
        {
            return Context.MotifAbsences.ToList();
        }
    }

    public class MotifRetardRepository : BaseRepository<MotifRetard>
    {
        public MotifRetardRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override MotifRetard Get(int id, bool includeRelatedEntity = true)
        {
            throw new NotImplementedException();
        }

        public override MotifRetard Get(string id)
        {
            return base.Get(id);
        }

        public override IList<MotifRetard> GetList()
        {
            return Context.MotifRetards.ToList();
        }
    }
}
