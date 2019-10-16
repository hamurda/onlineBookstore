using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class ReadingListBook :CoreEntity
    {
        public virtual Book Book { get; set; }
        public virtual ReadingList ReadingList { get; set; }
    }
}
