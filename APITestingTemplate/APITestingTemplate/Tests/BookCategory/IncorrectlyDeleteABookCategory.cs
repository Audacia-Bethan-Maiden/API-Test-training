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
    public class IncorrectlyDeleteABookCategory : ApiTestsBase
    {
        [Fact]
        public void Scenario_As_a_user_I_cannot_delete_a_book_category_if_I_use_the_Id_of_a_book_category_that_does_not_exist()
        {
            // Set the Id of the book Category you want to delete
            var bookCategoryId = Constants.BookCategoryIdThatDoesNotExist;

            // Call the API
            var bookCategoryResponse = Delete<BooleanCommandResult>(bookCategoryId, Resources.DeleteABookCategory);

            // Check the status code
            // Status code is 200 so the test fails but the category is deleted
            bookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the error message
            bookCategoryResponse.Content.Contains(
                "Unable to find book category with Id" + bookCategoryId);
        }
    }
}