namespace WebRazorTest.Data
{
    public class BookDb
    {
        private static readonly List<Book> Books;
        /*
         Private -> Bu listeye sadece GetBooks'tan eriş
         Static -> Bu liste üretildiği zaman ekleme(add) yapmamızı sağlar.
         Readonly -> Books = new List<Book>(); bu liste books'a atandığı zaman bir 
                            daha atama yapılmamasını sağlar.
         */

        public static void Initialize()
        {
            //    Books = new List<Book>
            //{
            //        new Book{Title = "İyi Kitap", Author = "Kötü Yazar", Id=0 },
            //        new Book{Title = "Kötü Kitap", Author = "İyi Kitap", Id=1 },
            //        new Book{Title = "İyi Kitap", Author = "İyi Kitap", Id=2 }
            //};

            Books = new List<Book>(); //Readonly'e bağlı bir durum (Araştır)
            Books.Add(new Book { Title = "İyi Kitap", Author = "Kötü Yazar", Id = 0 });
            Books.Add(new Book { Title = "Kötü Kitap", Author = "İyi Kitap", Id = 1 });
            Books.Add(new Book { Title = "İyi Kitap", Author = "İyi Kitap", Id = 2 });
        }

        public static IEnumerable<Book> GetBooks()
        {
            return Books;
        }

        public static Book GetBookById(int id)
        {
            return new Book();
        }
    }
}
