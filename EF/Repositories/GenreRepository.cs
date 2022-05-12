using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Models;
using EF.Helpers;

namespace EF.Repositories
{
    public class GenreRepository
    {
        private AppContext db;
        public GenreRepository(AppContext db) { this.db = db; }

        public Genre GetGenre()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) жанра:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return GetGenre();
            }

            Genre genre = GetGenre(id);
            return genre;
        }

        public Genre GetGenre(int id)
        {
            var Query =
            from genre in db.Genres
            where genre.Id == id
            select genre;

            Genre foundGenre = Query.FirstOrDefault() ?? new Genre();

            return foundGenre;
        }
    }
}
