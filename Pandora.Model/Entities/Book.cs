using Pandora.Core.Entity;
using Pandora.Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Book : CoreEntity
    {
        public string Title { get; set; }
        public Guid? AuthorID { get; set; }
        public Guid? TranslatorID { get; set; }
        public Guid? CategoryID { get; set; }
        public decimal? UnitPrice { get; set; }
        public Language Language { get; set; }
        public short? PageNo { get; set; }
        public string Description { get; set; }
        public Guid? PublisherID { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string ImagePath { get; set; }
        public decimal? MinUnitPrice { get; set; }
        public int? HowManySold { get; set; }


        //stackoverflow.com/questions/5559043/entity-framework-code-first-two-foreign-keys-from-same-table
        public virtual Author Author { get; set; }
        public virtual Author Translator { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual List<ReadingListBook> ReadingListBook { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<Search> Searches { get; set; }
        public virtual List<StockDetail> StockDetails { get; set; }

    }
}
