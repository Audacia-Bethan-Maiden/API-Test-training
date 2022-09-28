using System;
using System.Collections.Generic;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class AddBookTest : ApiTestsBase, IClassFixture<AddCategoryFixture>
    {
        private Random Random { get; } = new();
        private readonly AddCategoryFixture _addCategoryFixture;
        private readonly BookHelper _bookHelper;

        public AddBookTest(AddCategoryFixture addCategoryFixture)
        {
            _addCategoryFixture = addCategoryFixture;

            _bookHelper = new BookHelper();
        }
        [Fact]
        public void Scenario_8_As_a_user_I_can_add_a_book()
        {
            // Get the category Id of the new category
            var bookCategoryId = _addCategoryFixture.BookCategoryData.Id;
            // Set up the request to add the book
            var newBookRequest = SetupWithoutSave<AddBookRequest>();

            // Set the book category Id and generate other details
            newBookRequest.BookCategoryId = bookCategoryId;
            newBookRequest.Title = Random.Words(2);
            newBookRequest.Description = Random.Sentence();
            newBookRequest.Author = Random.Forename() + ' ' + Random.Surname();
            newBookRequest.PublishedYear = 1982;
            newBookRequest.HasEBook = true;
            newBookRequest.AvailableFrom = new DateTime(2022, 03, 20);

            // Call the API to add a book 
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code is created
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Check the title is actually there? Check by doing a get request to get the new book??? Need the book ID?
            // Check the output
            addBookResponse.Data.Output.Title.Should().Be(newBookRequest.Title);
            addBookResponse.Data.Output.Description.Should().Be(newBookRequest.Description);
            addBookResponse.Data.Output.Author.Should().Be(newBookRequest.Author);
            addBookResponse.Data.Output.PublishedYear.Should().Be(newBookRequest.PublishedYear);
            addBookResponse.Data.Output.AvailableFrom.Should().Be(newBookRequest.AvailableFrom);

            // Delete the book
            var bookId = addBookResponse.Data.Output.Id;
            _bookHelper.DeleteBook(bookId);
        }
    }
}

