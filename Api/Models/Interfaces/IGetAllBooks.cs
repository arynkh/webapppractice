using System.Collections.Generic;

namespace Api.Models.Interfaces
{
    public interface IGetAllBooks
    {
         List<Book> GetAllBooks();
    }
}