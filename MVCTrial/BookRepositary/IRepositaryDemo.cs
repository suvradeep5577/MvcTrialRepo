using MVCTrial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCTrial.BookRepositary
{
    public interface IRepositaryDemo
    {
        int Addbook(BookModel info);
        List<BookModel> getAllBook();
        BookModel getBookDetail(int id);
        Task<List<BookModel>> TopBook(int count);
    }
}