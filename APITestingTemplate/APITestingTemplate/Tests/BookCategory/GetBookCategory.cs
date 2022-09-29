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
    public class GetBookCategory : ApiTestsBase, IClassFixture<AddCategoryFixture>
    {
        private readonly AddCategoryFixture _addCategoryFixture;

        public GetBookCategory(AddCategoryFixture addCategoryFixture)
        {
            _addCategoryFixture = addCategoryFixture;
        }
        [Fact]
        public void Scenario_7_As_a_user_I_can_get_a_book_category()
        {
            // Get category details
            var bookCategoryName = _addCategoryFixture.BookCategoryData.Name;
            var bookCategoryId = _addCategoryFixture.BookCategoryData.Id;

            // Call the API to get a single book category
            var bookCategoryResponse = Get<GetBookCategoryDtoCommandResult>(bookCategoryId, Resources.GetBookCategory);

            // Check the status code
            bookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check its the right category
            bookCategoryResponse.Data?.Output.Name.Should().Be(bookCategoryName);
        }
    }
}

