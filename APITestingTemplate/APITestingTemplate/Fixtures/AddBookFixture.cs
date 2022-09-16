using System;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{
    public class AddBookFixture : ApiTestsBase, IDisposable
    {
        public GetBookDto BookData { get; }

        public AddBookFixture()
        {
            using var bookHelper = new BookHelper();

            BookData = bookHelper.CreateBook();
        }

        public void Dispose()
        {
            using var bookHelper = new BookHelper();

            bookHelper.DeleteBook(BookData.Id);
        }
    }
}

