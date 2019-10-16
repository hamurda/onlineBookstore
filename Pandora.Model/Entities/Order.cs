using Pandora.Core.Entity;
using Pandora.Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public Guid? ShipperID { get; set; }
        public virtual Shipper Shipper { get; set; }

        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid? BillAddressID { get; set; }
        public virtual Address BillAddress { get; set; }

        public Guid? ShipAddressID { get; set; }
        public virtual Address ShipAddress { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? Freight { get; set; }
        public string RecipientName { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsCustom { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
