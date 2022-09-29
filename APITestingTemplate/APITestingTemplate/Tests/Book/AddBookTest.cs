using System;
using System.Collections.Generic;
using System.Net;
using APITestingTemplate.DataSetup.Customizations.Books;
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

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_8_As_a_user_I_can_add_a_book()
        {
            // Get the category Id of the new category
            var bookCategoryId = _addCategoryFixture.BookCategoryData.Id;
            // Set up the request to add the book
            var newBookRequest = SetupWithoutSave<AddBookRequest>(new AddBookWithoutEBook());

            // Set the book category Id
            newBookRequest.BookCategoryId = bookCategoryId;

            // Call the API to add a book 
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code is created
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Check the output
            addBookResponse.Data?.Output.Title.Should().Be(newBookRequest.Title);
            addBookResponse.Data?.Output.Description.Should().Be(newBookRequest.Description);
            addBookResponse.Data?.Output.Author.Should().Be(newBookRequest.Author);
            addBookResponse.Data?.Output.PublishedYear.Should().Be(newBookRequest.PublishedYear);
            addBookResponse.Data?.Output.AvailableFrom.Should().Be(newBookRequest.AvailableFrom);
            addBookResponse.Data?.Output.HasEBook.Should().Be((bool)newBookRequest.HasEBook);

            // Delete the book
            var bookId = addBookResponse.Data.Output.Id;
            _bookHelper.DeleteBook(bookId);
        }
    }
}

