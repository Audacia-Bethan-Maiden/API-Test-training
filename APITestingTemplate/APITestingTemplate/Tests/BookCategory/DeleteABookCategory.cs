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
    public class DeleteABookCategory : ApiTestsBase, IClassFixture<AddCategoryWithoutDeleteFixture>
    {
        private readonly AddCategoryWithoutDeleteFixture _addCategoryWithoutDeleteFixture;

        public DeleteABookCategory(AddCategoryWithoutDeleteFixture addCategoryWithoutDeleteFixture)
        {
            _addCategoryWithoutDeleteFixture = addCategoryWithoutDeleteFixture;
        }
        [Fact]
        public void Scenario_As_a_user_I_can_delete_a_book_category()
        {
            // Set the Id of the book Category you want to delete
            var bookCategoryId = _addCategoryWithoutDeleteFixture.BookCategoryData.Id;

            // Call the API
            var bookCategoryResponse = Delete<CommandResult>(bookCategoryId, Resources.DeleteABookCategory);

            // Check the status code
            // Status code is 200 so the test fails but the category is deleted
            bookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check that the book was deleted
            // API call to get the book
            var deletedBookCategoryResponse = Get<GetBookCategoryDto>(bookCategoryId, Resources.GetBookCategory);

            // Check the status code is not found
            deletedBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Check the error message
            deletedBookCategoryResponse.Content.Contains(
                "Unable to find book category with Id" + bookCategoryId);
        }
    }
}