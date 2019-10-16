using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Category : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? SubCategoryOf { get; set; }

        [ForeignKey("SubCategoryOf")]
        public virtual Category CategorySubCategoryOf { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
