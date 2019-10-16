using Pandora.Model.Entities;
using Pandora.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Service.Option
{
    public class StockDetailService : BaseService<StockDetail>
    {
        DealerService ds = new DealerService();

        public short? GetTotalStock(Guid id)
        {
            List<StockDetail> stocks = this.GetAll();
            short? totalStock=0;

            foreach (StockDetail item in stocks)
            {
                if (item.Book.ID == id)
                {
                    totalStock += item.UnitsInStock;
                }
            }

            return totalStock;
        }

    }
}
