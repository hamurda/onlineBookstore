using Pandora.Model.Entities;
using Pandora.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Service.Option
{
    public class EmployeeService : BaseService<Employee>
    {
        public bool CheckCredentials(string email, string password)
        {
            return Any(x => x.EmailAddress == email && x.Password == password);
        }

        public Employee FindByUsername(string username)
        {
            return GetByDefault(x => x.Username == username);
        }

        public List<Employee> FindByName(string name)
        {
            return GetDefault(x => x.FirstName == name || x.LastName == name);
        }
    }
}
