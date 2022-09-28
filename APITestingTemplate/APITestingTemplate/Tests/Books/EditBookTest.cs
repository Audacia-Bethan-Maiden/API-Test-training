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
    public class EditBookTest : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;

        public EditBookTest(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
        }
        [Fact]
        public void Scenario_9_As_a_user_I_can_edit_a_book()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.Title = bookDetails.First().Title;
            editBookRequest.Description = bookDetails.First().Description;
            editBookRequest.Author = bookDetails.First().Author;
            editBookRequest.AvailableFrom = bookDetails.First().AvailableFrom;
            editBookRequest.PublishedYear = bookDetails.First().PublishedYear;
            editBookRequest.HasEBook = bookDetails.First().HasEBook;
            editBookRequest.BookCategoryId = bookDetails.First().BookCategoryId;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDtoCommandResult>(editBookRequest, Resources.EditBook);

            // Check the status code is 200
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check the details in the output
            editBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            editBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            editBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
        }
    }
}