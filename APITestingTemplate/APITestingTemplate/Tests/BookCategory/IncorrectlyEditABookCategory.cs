using System;
using System.Collections.Generic;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDtos;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.BookCategory
{
    public class IncorrectlyEditABookCategory : ApiTestsBase, IClassFixture<AddCategoryFixture>
    {
        private Random Random { get; } = new();
        private readonly AddCategoryFixture _addCategoryFixture;

        public IncorrectlyEditABookCategory(AddCategoryFixture addCategoryFixture)
        {
            _addCategoryFixture = addCategoryFixture;
        }
        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_As_a_user_I_cannot_update_a_book_category_if_I_do_not_include_the_category_Id()
        {
            // Get the category details
            var bookCategoryData = _addCategoryFixture.BookCategoryData;

            // Set update book category request
            var updateCategoryRequest = SetupWithoutSave<UpdateBookCategoryRequest>();

            // Call the API 
            var updateBookCategoryResponse =
                Put<GetBookCategoryDtoCommandResult>(updateCategoryRequest, Resources.EditBookCategory);

            // Check the status code
            updateBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the name of the category was not changed
            // Call API to get the category
            var getCategoryResponse =
                Get<GetBookCategoryDtoCommandResult>(bookCategoryData.Id, Resources.GetBookCategory);
            // Check the name of the category has not changed
            getCategoryResponse.Data.Output.Name.Should().Be(bookCategoryData.Name);
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_As_a_user_I_cannot_update_a_book_category_if_I_do_not_include_the_new_category_name()
        {
            // Get the category details
            var bookCategoryData = _addCategoryFixture.BookCategoryData;

            // Set update book category request
            var updateCategoryRequest = new UpdateBookCategoryRequest();
            updateCategoryRequest.Id = bookCategoryData.Id;

            // Call the API 
            var updateBookCategoryResponse =
                Put<GetBookCategoryDtoCommandResult>(updateCategoryRequest, Resources.EditBookCategory);

            // Check the status code
            updateBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the name of the category has not changed
            // Call the API to get the category
            var getCategoryResponse =
                Get<GetBookCategoryDtoCommandResult>(bookCategoryData.Id, Resources.GetBookCategory);
            // Check the name has not changed
            getCategoryResponse.Data.Output.Name.Should().Be(bookCategoryData.Name);
        }
        [Fact]
        public void Scenario_As_a_user_I_cannot_update_a_book_category_if_I_do_not_include_the_new_category_name_or_Id()
        {
            // Get the category details
            var bookCategoryData = _addCategoryFixture.BookCategoryData;

            // Set update book category request
            var updateCategoryRequest = new UpdateBookCategoryRequest();

            // Call the API 
            var updateBookCategoryResponse =
                Put<GetBookCategoryDtoCommandResult>(updateCategoryRequest, Resources.EditBookCategory);

            // Check the status code
            updateBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the name of the category has not changed
            // Call the API to get the category
            var getCategoryResponse =
                Get<GetBookCategoryDtoCommandResult>(bookCategoryData.Id, Resources.GetBookCategory);
            // Check the name has not changed
            getCategoryResponse.Data.Output.Name.Should().Be(bookCategoryData.Name);
        }
    }
}