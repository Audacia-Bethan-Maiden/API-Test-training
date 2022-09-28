using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class EmptyGetAllBooksFromACategory : ApiTestsBase, IClassFixture<AddCategoryFixture>
    {
        private readonly AddCategoryFixture _addCategoryFixture;

        public EmptyGetAllBooksFromACategory(AddCategoryFixture addCategoryFixture)
        {
            _addCategoryFixture = addCategoryFixture;
        }
        [Fact]
        public void Scenario_6_As_a_user_I_cannot_get_a_book_from_a_category_that_does_not_have_any_books()
        {
            // Get the book category data
            var bookCategoryData = _addCategoryFixture.BookCategoryData;
            var bookCategoryId = bookCategoryData.Id;

            // Call the API to get all books with the category Id
            var bookCategoryListResponse = GetAll<List<GetBookCategoryDto>>(Resources.GetBooksFromCategory(bookCategoryId.ToString()));

            // Check the status code is NOT OK (need to change later)
            bookCategoryListResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check the list is empty?
            bookCategoryListResponse.Content.Should().NotBeNull();
        }
    }
}
