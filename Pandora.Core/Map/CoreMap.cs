using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedDate).HasColumnName("Created Date").IsOptional();
            Property(x => x.CreatedIP).HasColumnName("Created IP").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("Updated Date").IsOptional();
            Property(x => x.UpdatedIP).HasColumnName("Updated ID").IsOptional();
        }
    }
}
