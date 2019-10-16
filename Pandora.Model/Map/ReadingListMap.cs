using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class ReadingListMap: CoreMap<ReadingList>
    {
        public ReadingListMap()
        {
            ToTable("dbo.ReadingLists");
            Property(x => x.ListName).HasMaxLength(50).IsRequired();
            Property(x => x.Description).IsOptional();
            Property(x => x.LogoPath).HasMaxLength(150).IsOptional();
        }
    }
}
