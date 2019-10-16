using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(x => x.BookID).IsRequired();
            Property(x => x.OrderID).IsRequired();
            Property(x => x.UnitPrice).HasColumnType("money").HasColumnName("UnitPrice").IsOptional();
            Property(x => x.Quantity).HasColumnName("Quantity").IsOptional();
            Property(x => x.IsReturn).IsOptional();
            Property(x => x.Discount).HasColumnType("real").IsOptional();
        }
    }
}
