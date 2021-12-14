using PhylogeneticTreeApi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.DataAccess
{
    public class HomeData : IHomeData
    {
        public async Task<IEnumerable<OutBranches>> getTyphologenetic(Branches[] data)
        {
            return await Task.FromResult(MakeTreeList(data.ToList(), 0));
        }

        static List<OutBranches> MakeTreeList(List<Branches> data, int parentStart)
        {
            return data.Where(x => x.Parent == parentStart).Select(x => new OutBranches
            {
                Id = x.Id,
                Name = x.Name,
                branch = MakeTreeList(data, Convert.ToInt32(x.Id))
            }).ToList();
        }
    }
}
