using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Models;
using EF.Helpers;

namespace EF.Repositories
{
    public class AutorRepository
    {
        private AppContext db;
        public AutorRepository(AppContext db) { this.db = db; }

        public Autor GetAutor()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) автора:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return GetAutor();
            }

            Autor autor = GetAutor(id);
            return autor;
        }

        public Autor GetAutor(int id)
        {
            var Query =
            from autor in db.Autors
            where autor.Id == id
            select autor;

            Autor foundAutor = Query.FirstOrDefault() ?? new Autor();

            return foundAutor;
        }

        public void AddAutor(AppContext db)
        {
            Autor autor = new();

            autor.Name = QuestionMessage.Question("Введите имя автора:");

            db.Autors.Add(autor);
            db.SaveChanges();

            SuccessMessage.Show("Автор добавлен успешно!");
        }
    }
}
