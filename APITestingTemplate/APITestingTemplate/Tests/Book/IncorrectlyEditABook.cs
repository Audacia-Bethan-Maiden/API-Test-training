using System;
using System.Collections.Generic;
using System.Linq;
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
    public class IncorrectlyEditABook : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private Random Random { get; } = new();
        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;

        public IncorrectlyEditABook(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
        }
        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_10_As_a_user_I_cannot_edit_a_book_if_I_use_a_book_Id_that_does_not_exist()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = 0;
            editBookRequest.BookCategoryId = 1;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDto>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details have not changed
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_11_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_book_title()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = 1;
            editBookRequest.Title = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDto>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details have not been changed
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_12_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_book_description()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = 1;
            editBookRequest.Description = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDto>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details 
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_13_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_book_author()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = 1;
            editBookRequest.Author = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDtoCommandResult>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details 
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_14_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_available_from_date()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = 1;
            editBookRequest.AvailableFrom = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDtoCommandResult>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details 
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_15_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_published_year()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = 1;
            editBookRequest.PublishedYear = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDtoCommandResult>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details 
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_16_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_has_e_book()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = 1;
            editBookRequest.HasEBook = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDtoCommandResult>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details 
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_17_As_a_user_I_cannot_edit_a_book_if_I_do_not_include_the_book_category_Id()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Details to edit
            var editBookRequest = SetupWithoutSave<UpdateBookRequest>();
            editBookRequest.Id = bookId;
            editBookRequest.BookCategoryId = null;

            // Call the API to edit the book
            var editBookResponse = Put<GetBookDtoCommandResult>(editBookRequest, Resources.EditBook);

            // Check the status code is 400
            editBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the details of the book haven't been changed
            // Get the book
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);
            // Check the details 
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.HasEBook.Should().BeTrue();
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
        }
    }
}

