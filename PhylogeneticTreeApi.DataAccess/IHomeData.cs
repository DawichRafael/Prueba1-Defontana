using PhylogeneticTreeApi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.DataAccess
{
    public interface IHomeData
    {
      IEnumerable<TreeNode> getTyphologenetic(Branch[] data);
    }
}
