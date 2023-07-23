using Microsoft.EntityFrameworkCore;
using MVCTrial.Data;
using MVCTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.BookRepositary
{
    public class RepositaryDemo : IRepositaryDemo
    {
        private readonly Context obj = null;

        public RepositaryDemo()
        {
            obj = new Context();
        }

        public int Addbook(BookModel info)
        {
            books ob = new books();
            ob.author = info.author;
            ob.title = info.title;
            ob.Language = info.Language;
            ob.Email = info.Email;
            ob.ImagePath = info.ImagePath;

            obj.books.Add(ob);
            obj.SaveChanges();

            return ob.ID;
        }


        public List<BookModel> getAllBook()
        {
            List<BookModel> listbook = new List<BookModel>();
            var data = obj.books.ToList();
            if (data?.Any() == true)
            {
                foreach (var item in data)
                {
                    BookModel bookOb1 = new BookModel();
                    bookOb1.title = item.title;
                    bookOb1.author = item.author;
                    bookOb1.ID = item.ID;

                    listbook.Add(bookOb1);
                }
            }
            return listbook;
        }

        public BookModel getBookDetail(int id)
        {
            BookModel b1 = new BookModel();

            var info = obj.books.Find(id);

            if (b1 != null)
            {
                b1.title = info.title;
                b1.author = info.author;
                b1.ID = info.ID;
                b1.ImagePath = info.ImagePath;


            }


            return b1;

            //return DataSource().Where(x => x.ID == id).FirstOrDefault();
        }

        private List<BookModel> DataSource()
        {
            var data = new List<BookModel>() {
                new BookModel(){ ID = 1, title="Bill",author="Demo1"},
                new BookModel(){ ID = 2, title="Steve",author="Demo2"},
                new BookModel(){ ID = 3, title="Ram",author="Demo3"},
                new BookModel(){ ID = 4, title="Abdul",author="Demo4"}
            };

            return data;
        }

        public async Task<List<BookModel>> TopBook(int count)
        {
            //List<BookModel> listbook = new List<BookModel>();
            //var data = obj.books.Take(2).ToList();
            //if (data?.Any() == true)
            //{
            //    foreach (var item in data)
            //    {
            //        BookModel bookOb1 = new BookModel();
            //        bookOb1.title = item.title;
            //        bookOb1.author = item.author;
            //        bookOb1.ID = item.ID;

            //        listbook.Add(bookOb1);
            //    }
            //}
            //return listbook;

            var data = await obj.books.Select(item => new BookModel()
            {


                title = item.title,
                author = item.author,
                ID = item.ID

            }).Take(count).ToListAsync();

            return data;
        }

    }
}
