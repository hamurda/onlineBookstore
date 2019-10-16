using Pandora.Model.Entities;
using Pandora.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pandora.Service.Option
{
    public class BookService : BaseService<Book>
    {
        public bool CheckBook(Book item, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                return false;
            }

            return Any(m => m.Title == item.Title && m.PublisherID == item.PublisherID && m.PublicationDate == m.PublicationDate && m.Language == item.Language && m.AuthorID == item.AuthorID && m.TranslatorID == item.TranslatorID);
        }

        public List<Book> SelectBestSellers()
        {
            List<Book> bestSeller = Context.Books.OrderByDescending(m => m.HowManySold).Take(5).ToList();

            return bestSeller;       
        }

        public int? GetStock(Guid id)
        {
            int? stock = 0;
            List<StockDetail> sds = Context.StockDetails.Where(m => m.BookID == id).ToList();
            foreach (var item in sds)
            {
                stock += item.UnitsInStock;
            }

            return stock;
        }
    }
}
