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
        private readonly Random _random = new Random();

        public GetBookDto CreateBook()
        {
            // Set up the request to add the book
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

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
                AvailableFrom = addBookResponse.Data.Output.AvailableFrom,
                HasEBook = true,
                BookCategoryId = 1,
                Id = addBookResponse.Data.Output.Id
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
