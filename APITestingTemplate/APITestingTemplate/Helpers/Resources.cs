using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestingTemplate.Helpers
{
    public static class Resources
    {
        // Book
        public static string AddBook = "Book/Add";

        public static string AddBookCategory = "BookCategory/Add";

        public static string DeleteBook = "Book/";

        public static string DeleteABookCategory = "BookCategory/";

        public static string EditBook = "Book/Update";

        public static string EditBookCategory = "BookCategory/Update";

        public static string GetBookById = "Book";

        public static string GetAllBooks = "Book/GetAll";

        public static string GetAllBookCategories = "BookCategory/GetAll";

        private const string GetBooksFromCategoryFormat = "BookCategory/{0}/Books";

        public static string GetBooksFromCategory(string bookId) => string.Format(GetBooksFromCategoryFormat, bookId);

        public static string GetBookCategory = "BookCategory/";
    }
}
