using BSLibrary.Models;

namespace BSLibrary.Database
{
    public class MemoryDatabase
    {
        public List<Book> db;
        public MemoryDatabase()
        {
            db = new List<Book>
          {
            new Book { Id = 1, Title = "The Great Adventure", Author = "John Doe", Genre = "Adventure", PublishedDate = new DateTime(2020, 1, 15), ISBN = "9781234567890" },
            new Book { Id = 2, Title = "Learning C#", Author = "Jane Smith", Genre = "Programming", PublishedDate = new DateTime(2021, 3, 10), ISBN = "9781234567891" },
            new Book { Id = 3, Title = "Mystery of the Night", Author = "Alice Johnson", Genre = "Mystery", PublishedDate = new DateTime(2019, 6, 25), ISBN = "9781234567892" },
            new Book { Id = 4, Title = "Science of Life", Author = "Bob Lee", Genre = "Science", PublishedDate = new DateTime(2022, 7, 5), ISBN = "9781234567893" },
            new Book { Id = 5, Title = "History of the World", Author = "Mark Evans", Genre = "History", PublishedDate = new DateTime(2018, 11, 10), ISBN = "9781234567894" },
            new Book { Id = 6, Title = "The Art of Cooking", Author = "Sophia Brown", Genre = "Cookbook", PublishedDate = new DateTime(2020, 8, 30), ISBN = "9781234567895" },
            new Book { Id = 7, Title = "The Dark Forest", Author = "David Wilson", Genre = "Science Fiction", PublishedDate = new DateTime(2021, 4, 15), ISBN = "9781234567896" },
            new Book { Id = 8, Title = "Fantasy Realms", Author = "Emily Green", Genre = "Fantasy", PublishedDate = new DateTime(2017, 9, 9), ISBN = "9781234567897" },
            new Book { Id = 9, Title = "Healthy Living", Author = "Sarah Moore", Genre = "Health", PublishedDate = new DateTime(2020, 12, 1), ISBN = "9781234567898" },
            new Book { Id = 10, Title = "Adventure in Space", Author = "James Carter", Genre = "Science Fiction", PublishedDate = new DateTime(2023, 1, 20), ISBN = "9781234567899" }
          };
        }

        public List<Book> Get()
        {
            return db;
        }

        public Book Get(int Id)
        {
            return db.FirstOrDefault(t => t.Id == Id);
        }
        public void Add(Book book)
        {
            int maxId = db.Any() ? db.Max(b => b.Id) : 0;
            book.Id = maxId + 1;
            db.Add(book);
        }

        public void Remove(Book trainee)
        {
            db.Remove(trainee);
        }

        public void Update(Book book)
        {
            var bookToUpdate = db.FirstOrDefault(b => b.Id == book.Id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.PublishedDate = book.PublishedDate;
                bookToUpdate.ISBN = book.ISBN;
                bookToUpdate.UpdatedAt = DateTime.Now;  
            }
        }
    }
}