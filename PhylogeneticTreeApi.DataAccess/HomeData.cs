using PhylogeneticTreeApi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.DataAccess
{
    public class HomeData : IHomeData
    {
        public IEnumerable<TreeNode> getTyphologenetic(Branch[] data)
        {
            return MakeTreeList(data.ToList(), 0);
        }

        static List<TreeNode> MakeTreeList(List<Branch> data, int v)
        {
            return data.Where(x => x.Parent == v).Select(x => new TreeNode
            {
                Id = x.Id,
                Name = x.Name,
                branch = MakeTreeList(data, Convert.ToInt32(x.Id))
            }).ToList();
        }
    }
}
