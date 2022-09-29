using System;
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
    public class IncorrectlyDeleteABook : ApiTestsBase
    {
        [Fact]
        public void Scenario_As_a_user_I_cannot_delete_a_book_that_does_not_exist()
        {
            // Set the book Id of the book to be deleted
            var bookId = Constants.BookIdThatDoesNotExist;

            // Call the API to delete the book 
            var deleteBookResponse = Delete<BooleanCommandResult>(bookId, Resources.DeleteBook);

            // Check the status code 
            deleteBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the error message
            deleteBookResponse.Content.Contains("Unable to find book with Id" + bookId);
        }
    }
}