using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Random;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class GetAllBookCategories : ApiTestsBase, IClassFixture<AddManyCategoriesFixture>
    {
        private readonly AddManyCategoriesFixture _addManyCategoriesFixture;

        public GetAllBookCategories(AddManyCategoriesFixture addManyCategoriesFixture)
        {
            _addManyCategoriesFixture = addManyCategoriesFixture;
        }
        [Fact]
        public void Scenario_4_As_a_user_I_can_get_all_book_categories()
        {
            // Save some names of book categories
            var bookCategoryOneName = _addManyCategoriesFixture.BookCategoryDataList[0].Name;
            var bookCategoryTwoName = _addManyCategoriesFixture.BookCategoryDataList[1].Name;

            // Call the API to get all the book categories
            var getBookCategoriesResponse = GetAll<List<GetBookCategoryDto>>(Resources.GetAllBookCategories);

            // Check the status code of the response
            getBookCategoriesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check some book categories are there
            getBookCategoriesResponse.Data[getBookCategoriesResponse.Data.Count - 2].Name.Should().Be(bookCategoryOneName);
            getBookCategoriesResponse.Data.Last().Name.Should().Be(bookCategoryTwoName);
        }
    }
}

