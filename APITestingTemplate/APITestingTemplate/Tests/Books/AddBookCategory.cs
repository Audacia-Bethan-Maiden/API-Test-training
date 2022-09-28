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
    public class AddBookCategory : ApiTestsBase
    {
        private Random Random { get; } = new();
        private readonly BookCategoryHelper _bookCategoryHelper;

        public AddBookCategory()
        {
            _bookCategoryHelper = new BookCategoryHelper();
        }
        [Fact]
        public void Scenario_As_a_user_I_can_add_a_book_category()
        {
            // Set up details for the book category you want to add
            var bookCategoryRequest = SetupWithoutSave<AddBookCategoryRequest>();
            bookCategoryRequest.Name = Random.Words(2);

            // Call the API
            var addCategoryResponse =
                Post<GetBookCategoryDtoCommandResult>(bookCategoryRequest, Resources.AddBookCategory);

            // Check the status code
            addCategoryResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Check the name
            addCategoryResponse.Data.Output.Name.Should().Be(bookCategoryRequest.Name);

            // Delete the new category
            // Call the API to delete the category
            var bookCategoryId = addCategoryResponse.Data.Output.Id;
            _bookCategoryHelper.DeleteBookCategory(bookCategoryId);
        }
    }
}