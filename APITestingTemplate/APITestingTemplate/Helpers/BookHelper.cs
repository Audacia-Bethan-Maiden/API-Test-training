using System;
using System.Net;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;

namespace APITestingTemplate.Helpers
{
    public class BookHelper : ApiTestsBase
    {
        private Random Random { get; } = new();

        private readonly BookHelper _bookHelper;

        public BookHelper()
        {
            _bookHelper = new BookHelper();
        }

        public GetBookDto CreateBook()
        {
            // Set up the request to add the book
            var addBookRequest = SetupWithoutSave<AddBookRequest>();
            addBookRequest.Title = Random.Words(2);
            addBookRequest.Description = Random.Sentence();
            addBookRequest.Author = Random.FemaleForename() + Random.Surname();
            addBookRequest.PublishedYear = 2015;
            addBookRequest.AvailableFrom = DateTimeOffset.Now;
            addBookRequest.HasEBook = true;
            addBookRequest.BookCategoryId = 1;

            // Send the request to add the book
            var addBookResponse =
                Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook, null);
            // Check the correct response is returned
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Return the book values as the GetBookDto
            return new GetBookDto()
            {
                Title = addBookResponse.Data.Output.Title,
                Description = addBookResponse.Data.Output.Description,
                Author = addBookResponse.Data.Output.Author,
                PublishedYear = addBookResponse.Data.Output.PublishedYear,
                AvailableFrom = DateTimeOffset.Now,
                HasEBook = true,
                BookCategoryId = 1
            };
        }

        public void DeleteBook(int bookId)
        {
            // Call the API to delete a book
            var deleteBookResponse = Delete(bookId, Resources.DeleteBook, null);

            // Check the correct response is returned
            deleteBookResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
