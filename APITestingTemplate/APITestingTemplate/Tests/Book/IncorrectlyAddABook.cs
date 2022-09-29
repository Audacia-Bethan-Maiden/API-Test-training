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
    public class IncorrectlyAddABookTest : ApiTestsBase
    {
        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_18_As_a_user_I_cannot_add_a_book_if_I_do_not_include_a_book_title()
        {
            // Set up details for the new book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.Title = null;
            newBookRequest.BookCategoryId = 1;

            // Call the API to add the book
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_19_As_a_user_I_cannot_add_a_book_if_I_do_not_include_a_book_description()
        {
            // Set up details for the new book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.Description = null;
            newBookRequest.BookCategoryId = 1;

            // Call the API to add the book
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code of the response
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_20_As_a_user_I_cannot_add_a_book_if_I_do_not_include_a_book_author()
        {
            // Set up the details for the book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.Author = null;
            newBookRequest.BookCategoryId = 1;

            // Call the API to add the book
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category","Not Core")]
        [Fact]
        public void Scenario_21_As_a_user_I_cannot_add_a_book_if_I_do_not_include_the_published_year()
        {
            // Set up the details of the book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.PublishedYear = null;
            newBookRequest.BookCategoryId = 1;

            // Call the API to add the book
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_22_As_a_user_I_cannot_add_a_book_if_I_do_not_include_available_from_date()
        {
            // Set up the details for the book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.AvailableFrom = null;
            newBookRequest.BookCategoryId = 1;

            // Call the API to add the book
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_23_As_a_user_I_cannot_add_a_book_if_I_do_not_include_has_e_book()
        {
            // Set up the details for the book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.BookCategoryId = 1;
            newBookRequest.HasEBook = null;

            // Call the API to add the book
            var addBookResponse = Post<GetBookDtoCommandResult>(newBookRequest, Resources.AddBook);

            // Check the status code
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_24_As_a_user_I_cannot_add_a_book_if_I_do_not_include_a_book_category()
        {
            // Set up details for the book you want to add
            var newBookRequest = SetupWithoutSave<AddBookRequest>();
            newBookRequest.BookCategoryId = null;

            // Call the API to add a book 
            var addBookResponse = Post<GetBookDto>(newBookRequest, Resources.AddBook);

            // Check the status code is created
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the title is not there? Check by doing a get request to get the new book??? Need the book ID for that
        }
    }
}