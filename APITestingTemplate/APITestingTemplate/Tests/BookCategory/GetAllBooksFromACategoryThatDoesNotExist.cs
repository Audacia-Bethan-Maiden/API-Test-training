using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.BookCategory
{
    public class GetAllBooksFromACategoryThatDoesNotExist : ApiTestsBase
    {
        [Fact]
        public void Scenario_As_a_user_I_can_get_all_books_from_a_category_that_does_not_exist()
        {
            var bookCategoryId = Constants.BookCategoryIdThatDoesNotExist;

            // Call API to get all the book categories
            var bookCategoryResponse = GetAll<List<GetBookDtoIEnumerableCommandResult>>(Resources.GetBooksFromCategory(bookCategoryId.ToString()));

            // Check the status code is NOT OK (need to change later)
            bookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check the list is empty?
            bookCategoryResponse.Content.Should().NotBeNull();

        }
    }
}
