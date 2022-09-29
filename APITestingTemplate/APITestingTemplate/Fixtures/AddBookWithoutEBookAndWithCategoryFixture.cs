using System.Linq;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDtos;

namespace APITestingTemplate.Fixtures
{
    public class AddBookWithoutEBookAndWithCategoryFixture
    {
        public AddBookAndCategoryData BookData { get; }

        public AddBookWithoutEBookAndWithCategoryFixture()
        {
            using var bookHelper = new BookHelper();

            BookData = bookHelper.AddBookWithNewCategoryAndNoEBook();
        }

        public void Dispose()
        {
            using var bookHelper = new BookHelper();

            bookHelper.DeleteBookAndCategory(BookData.BookCategoryData.First().Id, BookData.BookData.First().Id);
        }
    }
}