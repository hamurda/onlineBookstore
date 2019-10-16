using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Search : CoreEntity
    {
        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }

        public int Count { get; set; }
    }
}
