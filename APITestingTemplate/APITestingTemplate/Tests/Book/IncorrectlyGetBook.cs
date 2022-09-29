using System.Collections.Generic;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class IncorrectlyGetBook : ApiTestsBase
    {
        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_3_As_a_user_I_cannot_get_a_single_book_if_I_use_an_Id_that_does_not_exist()
        {
            // Set the book ID to and ID that doesn't exist
            var bookId = Constants.BookIdThatDoesNotExist;

            // Call the API to get a book using the Id
            var getBookResponse = Get<GetBookDto>(bookId, Resources.GetBookById);

            // Check the status code is a bad request
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the error message
            getBookResponse.Content.Contains("Unable to find Book with Id: " + bookId);
        }
    }
}

