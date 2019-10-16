using Pandora.Core.Entity;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Author : CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorLabel {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }              
        }


        public virtual List<Book> WrittenBooks { get; set; }
        public virtual List<Book> TranslatedBooks { get; set; }
    }
}
