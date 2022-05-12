using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Models;
using EF.Helpers;
using EF.Repositories;

namespace EF
{
    public class BookRepository
    {
        private AppContext db;
        public BookRepository(AppContext db)
        {
            this.db = db;
        }

        public void GetBookByID()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким идентификатором в базе отсутствует.");
                return;
            }

            ShowBookData(book);
        }

        public void GetAllBooks()
        {
            var books = db.Books.ToList();
            if (books.Count == 0)
            {
                AlertMessage.Show("В базе отсутствуют книги.");
                return;
            }

            int currentBook = 1;
            foreach (var book in books)
            {
                Console.WriteLine("+------------------------ Книга #{currentbook}------------------------+", currentBook);
                ShowBookData(book);
                currentBook++;
            }
        }

        private void ShowBookData(Book book)
        {
            Console.WriteLine("Информация о книге:");
            Console.WriteLine("Идентификатор: {0}", book.Id);
            Console.WriteLine("Наименование: {0}", book.Title);
            Console.WriteLine("Год издания: {0}", book.ReleaseYear);
        }

        private Book GetBook(int id)
        {
            var Query =
            from book in db.Books
            where book.Id == id
            select book;

            Book foundbook = Query.FirstOrDefault() ?? new Book();

            return foundbook;
        }
        private void UpdateBookData(ref Book book)
        {
            AutorRepository autorRepository = new(db);
            GenreRepository genreRepository = new(db);

            book.Title = QuestionMessage.Question("Введите наименование книги:");

            int year;
            
            int.TryParse(QuestionMessage.Question("Введите год издания книги:"), out year);
            book.ReleaseYear = year;

            book.Autor = autorRepository.GetAutor();
            book.AutorID = book.Autor.Id;
            book.Genre = genreRepository.GetGenre();
            book.GenreId = book.Genre.Id;

            db.SaveChanges();
            SuccessMessage.Show("Данные успешно обновлены!");
        }

        public void AddNewBook()
        {
            Book book = new Book();

            UpdateBookData(ref book);

            db.Books.Add(book);
            db.SaveChanges();

            SuccessMessage.Show("Книга успешно добавлена.");
        }

        public void UpdateBook()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким идентификатором в базе отсутствует.");
                return;
            }

            UpdateBookData(ref book);

        }

        public void RemoveBook()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким идентификатором в базе отсутствует.");
                return;
            }
            
            db.Books.Remove(book);
            db.SaveChanges();

            SuccessMessage.Show("Книга успешно удалена.");
        }

        public void IssueBookToUser()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким идентификатором в базе отсутствует.");
                return;
            }

            UserRepository userRepository = new(db);
            User user = userRepository.GetUser();

            if (user.Id == 0)
            {
                AlertMessage.Show("Пользователь с таким идентификатором в базе отсутствует.");
                return;
            }

            Logbook logBook = new();
            logBook.User = user;
            logBook.Book = book;

            db.Logbook.Add(logBook);
            db.SaveChanges();

            SuccessMessage.Show("Книга успешно выдана пользователю.");
        }
    }
}
