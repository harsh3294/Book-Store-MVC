using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    interface IBook
    {
        IEnumerable<Data.Entities.Book> GetBooks();
        Data.Entities.Book GetBookById(int id);
        void AddBook(Data.Entities.Book book);
        void UpdateBookById(int id, Data.Entities.Book book);
        void DeleteBookById(int id);
        void save();
    }
}
