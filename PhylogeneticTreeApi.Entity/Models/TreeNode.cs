using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.Entity.Models
{
    public class TreeNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<TreeNode> branch{ get; set; }
    }
}
