using Pandora.Model.Entities;
using Pandora.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Service.Option
{
    public class CustomerService : BaseService<Customer>
    {
        public bool checkCredentials(string email, string password)
        {
            return Any(x => x.EmailAddress == email && x.Password == password);
        }

        public Customer FindByUsername(string username)
        {
            return GetByDefault(x => x.Username == username);
        }

        public bool CheckEmail(string email)
        {
            return Any(x => x.EmailAddress == email);
        }
    }
}
