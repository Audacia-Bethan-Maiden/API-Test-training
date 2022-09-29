using System;
using System.Collections.Generic;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.BookCategory
{
    public class EditABookCategory : ApiTestsBase, IClassFixture<AddCategoryFixture>
    {
        private readonly AddCategoryFixture _addCategoryFixture;

        public EditABookCategory(AddCategoryFixture addCategoryFixture)
        {
            _addCategoryFixture = addCategoryFixture;
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_As_a_user_I_can_update_the_name_of_a_book_category()
        {
            // Get category details
            var bookCategoryId = _addCategoryFixture.BookCategoryData.Id;

            // Set update book category request
            var updateCategoryRequest = SetupWithoutSave<UpdateBookCategoryRequest>();
            updateCategoryRequest.Id = bookCategoryId;

            // Call the API 
            var updateBookCategoryResponse =
                Put<GetBookCategoryDtoCommandResult>(updateCategoryRequest, Resources.EditBookCategory);

            // Check the status code
            updateBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check the name in the response
            updateBookCategoryResponse.Data.Output.Name.Should().Be(updateCategoryRequest.Name);
        }
    }
}