using Pandora.Model.Entities;
using Pandora.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Service.Option
{
    public class AuthorService : BaseService<Author>
    {
        public bool CheckAuthor(Author item)
        {
            return Any(x => x.FirstName == item.FirstName && x.LastName == item.LastName);
        }

    }
}
