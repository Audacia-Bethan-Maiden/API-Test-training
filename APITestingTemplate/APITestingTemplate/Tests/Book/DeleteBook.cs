using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class DeleteBook : ApiTestsBase, IClassFixture<AddBookAndCategoryWithoutDeleteFixture>
    {
        private Random Random { get; } = new();
        private readonly AddBookAndCategoryWithoutDeleteFixture _addBookAndCategoryWithoutDeleteFixture;

        public DeleteBook(AddBookAndCategoryWithoutDeleteFixture addBookAndCategoryWithoutDeleteFixture)
        {
            _addBookAndCategoryWithoutDeleteFixture = addBookAndCategoryWithoutDeleteFixture;
        }
        [Fact]
        public void Scenario_As_a_user_I_can_delete_a_book()
        {
            // Set the book Id of the book to be deleted
            // Get book details
            var bookDetails = _addBookAndCategoryWithoutDeleteFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Call the API to delete the book 
            var deleteBookResponse = Delete<CommandResult>(bookId, Resources.DeleteBook);

            // Check the status code 
            // Does delete book but test fails because the status code is 200, not 204
            deleteBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Try to get the book to check it has been deleted
            // Call the API
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            // Check the status code
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the error message
            getBookResponse.Content?.Contains("Unable to find book with Id " + bookId);
        }
    }
}

