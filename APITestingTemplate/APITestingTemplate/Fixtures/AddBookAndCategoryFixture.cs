using System;
using System.Linq;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDtos;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{
    public class AddBookAndCategoryFixture : ApiTestsBase, IDisposable
    {
        public AddBookAndCategoryData BookData { get; }

        public AddBookAndCategoryFixture()
        {
            using var bookHelper = new BookHelper();

            BookData = bookHelper.AddBookWithNewCategory();
        }

        public void Dispose()
        {
            using var bookHelper = new BookHelper();

            bookHelper.DeleteBookAndCategory(BookData.BookCategoryData.First().Id, BookData.BookData.First().Id);
        }
    }
}

