using PhylogeneticTreeApi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.DataAccess
{
    public class HomeData : IHomeData
    {
        public IEnumerable<OutBranches> getTyphologenetic(Branches[] data)
        {
            return MakeTreeList(data.ToList(), 0);
        }

        static List<OutBranches> MakeTreeList(List<Branches> data, int v)
        {
            return data.Where(x => x.Parent == v).Select(x => new OutBranches
            {
                Id = x.Id,
                Name = x.Name,
                branch = MakeTreeList(data, Convert.ToInt32(x.Id))
            }).ToList();
        }
    }
}
