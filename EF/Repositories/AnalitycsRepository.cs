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
    public class AnalitycsRepository
    {
        private AppContext db;
        private UserRepository userRepository;
        private BookRepository bookRepository;
        private AutorRepository autorRepository;
        private GenreRepository genreRepository;

        public AnalitycsRepository(AppContext db)
        {
            this.db = db;
            userRepository = new UserRepository(db);
            bookRepository = new BookRepository(db);
            autorRepository = new AutorRepository(db);
            genreRepository = new GenreRepository(db);
        }

        public int GetBooksCount()
        {
            var Query =
            from book in db.Books
            select book;

            return Query.ToList().Count();
        }

        public void GetBooksCountForAutor()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) автора:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Autor autor = autorRepository.GetAutor(id);
            if (autor.Id == 0)
            {
                AlertMessage.Show("Автор с таким идентификатором в базе отсутствует.");
                return;
            }

            var Query =
            from book in db.Books
            where book.Autor == autor
            select book;

            SuccessMessage.Show("В базе имеется " + Query.Count().ToString() + " книг автора " + autor.Name);
        }

        public void GetBooksCountForGenre()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) жанра:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Жанр с таким идентификатором в базе отсутствует.");
                return;
            }
            
            var Query =
            from book in db.Books
            where book.Genre == genre
            select book;

            SuccessMessage.Show("В базе имеется " + Query.Count().ToString() + " жанра " + genre.Name);
        }

        public void GetBooksOfGenre()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) жанра:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Жанр с таким идентификатором в базе отсутствует.");
                return;
            }

            var Query =
            from book in db.Books
            where book.Genre == genre
            select book;

            foreach(var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void GetBooksOfGenreAndReleaseYear()
        {

            var stringId = QuestionMessage.Question("Введите идентификатор (id) жанра:");

            int id, releaseYear;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Жанр с таким идентификатором в базе отсутствует.");
                return;
            }

            stringId = QuestionMessage.Question("Введите год выхода книги:");

            result = int.TryParse(stringId, out releaseYear);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            var Query =
            from book in db.Books
            where (book.Genre == genre) && (book.ReleaseYear == releaseYear)
            select book;

            foreach(var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void ListBooksOverPeriod()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) жанра:");

            int id, startYear, endYear;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Автор с таким идентификатором в базе отсутствует.");
                return;
            }

            stringId = QuestionMessage.Question("Введите начальный год периода:");

            result = int.TryParse(stringId, out startYear);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            stringId = QuestionMessage.Question("Введите конечный год периода:");

            result = int.TryParse(stringId, out endYear);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            var Query =
            from book in db.Books
            where (book.Genre == genre) && ((book.ReleaseYear >= startYear) ^ (book.ReleaseYear <= endYear))
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void GetBooksTitleAscending()
        {
            var Query =
            from book in db.Books
            orderby book.Title
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }

        }

        public void GetBooksTitleDescending()
        {
            var Query =
            from book in db.Books
            orderby book.Title descending
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }

        }

        public void GetBooksReleaseYearAscending()
        {
            var Query =
            from book in db.Books
            orderby book.ReleaseYear
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }

        }

        public void GetBooksReleaseYearADescending()
        {
            var Query =
            from book in db.Books
            orderby book.ReleaseYear descending
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }

        }

        public void ThereIsABookInTheLibrary()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) автора:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Autor autor = autorRepository.GetAutor(id);
            if (autor.Id == 0)
            {
                AlertMessage.Show("Автор с таким идентификатором в базе отсутствует.");
                return;
            }

            var bookTitle = QuestionMessage.Question("Введите наименование книги:");

            var Query =
            from book in db.Books
            where (book.Autor == autor) && (book.Title == bookTitle)
            select book;

            if (Query.Count() > 0) { SuccessMessage.Show("Такая книга есть в библиотеке."); return; }

            SuccessMessage.Show("Такая книга в библиотеке отсутствует.");
        }

        public void UserHasBook()
        {
            User user = userRepository.GetUser();
            Book book = bookRepository.GetBook();
            
            var Query =
            from record in db.Logbook
            where (record.User == user) && (record.Book == book)
            select record;

            if (Query.Count() > 0) { SuccessMessage.Show("Такая книга есть в библиотеке."); return; }

            SuccessMessage.Show("Такая книга в библиотеке отсутствует.");
        }

        public void NumberOfBooksUser()
        {
            User user = userRepository.GetUser();

            var Query =
            from record in db.Logbook
            where record.User == user
            select record;

            SuccessMessage.Show("Книг на руках у пользователя: " + Query.Count().ToString());
        }

        public void LatestPublishedBook()
        {
            var Query =
            from book in db.Books
            orderby book.ReleaseYear descending
            select book;

            var ourBook = Query.FirstOrDefault();
            SuccessMessage.Show("Последняя вышедшая книга: " + ourBook.Title + "; год выхода: " + ourBook.ReleaseYear.ToString());
        }
    }
}
