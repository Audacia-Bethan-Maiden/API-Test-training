using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDtos;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class GetSingleBook : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;

        public GetSingleBook(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
        }

        [Trait("Category", "Core")]
        [Fact]
        public void Scenario_1_As_a_user_I_can_get_a_book_by_its_Id()
        {
            // Get book details
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookDetails.First().Id;

            // Call the get API to get the book by its ID
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            // Check the status code is ok
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check that the book details are correct
            getBookResponse.Data?.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data?.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data?.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data?.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            getBookResponse.Data?.Output.BookCategoryId.Should().Be(bookDetails.First().BookCategoryId);
            getBookResponse.Data?.Output.HasEBook.Should().Be(bookDetails.First().HasEBook);
            getBookResponse.Data?.Output.Id.Should().Be(bookDetails.First().Id);
        }
    }
}