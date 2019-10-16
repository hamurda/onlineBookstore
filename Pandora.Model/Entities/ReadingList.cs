using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class ReadingList : CoreEntity
    {
        public ReadingList()
        {
            this.ReadingListBook = new List<ReadingListBook>();
        }

        public string ListName { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }

        public virtual List<ReadingListBook> ReadingListBook { get; set; }
    }
}
