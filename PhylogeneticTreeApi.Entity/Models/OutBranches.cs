﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.Entity.Models
{
    public class OutBranches
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<OutBranches> branch{ get; set; }
    }
}