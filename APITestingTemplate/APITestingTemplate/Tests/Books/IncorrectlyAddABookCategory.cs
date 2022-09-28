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
    public class IncorrectlyAddABookCategory : ApiTestsBase
    {
        [Fact]
        public void Scenario_As_a_user_I_cannot_add_a_book_category_if_I_do_not_include_the_name_of_the_category()
        {
            // Set up details for the book category you want to add
            var bookCategoryRequest = new AddBookCategoryRequest();

            // Call the API
            var addCategoryResponse =
                Post<GetBookCategoryDtoCommandResult>(bookCategoryRequest, Resources.AddBookCategory);

            // Check the status code
            addCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}