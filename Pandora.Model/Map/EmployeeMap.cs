using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class EmployeeMap : CoreMap<Employee>
    {
        public EmployeeMap()
        {
            ToTable("dbo.Employees");
            Property(x => x.ReportsTo).IsOptional();
            Property(x => x.Extension).HasMaxLength(6).IsOptional();
            Property(x => x.FirstName).HasMaxLength(30).IsOptional();
            Property(x => x.LastName).HasMaxLength(30).IsOptional();
            Property(x => x.PhotoPath).HasMaxLength(100).IsOptional();
            Property(x => x.HomePhone).HasMaxLength(20).IsOptional();
            Property(x => x.BirthDate).IsOptional();
            Property(x => x.HireDate).IsOptional();
            Property(x => x.AddressID).IsOptional();
            Property(x => x.DealerID).IsOptional();
            Property(x => x.Password).HasMaxLength(20).IsRequired();
        }
    }
}
