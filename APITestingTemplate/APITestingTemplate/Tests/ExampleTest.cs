using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests
{
    public class GetBooksTests : ApiTestsBase, IClassFixture<AddBookFixture>
    {
        private readonly AddBookFixture _addBookFixture;

        public GetBooksTests(AddBookFixture addBookFixture)
        {
            _addBookFixture = addBookFixture;
        }

        [Fact]
        public void Scenario_1_As_a_user_I_can_get_a_book_by_its_Id()
        {
            // Set the bookId you wish to get
            var bookDetails = _addBookFixture.BookData;
            var bookId = bookDetails.Id;

            // Call the get API to get the book by its ID
            var getBookResponse = Get<GetBookDto>(bookId, Resources.GetBookById);

            // Check the status code is ok
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check that the book details are correct
            getBookResponse.Data.Title.Should().Be(bookDetails.Title);
            getBookResponse.Data.Author.Should().Be(bookDetails.Author);
            getBookResponse.Data.Description.Should().Be(bookDetails.Description);
            getBookResponse.Data.PublishedYear.Should().Be(bookDetails.PublishedYear);
            getBookResponse.Data.AvailableFrom.Should().Be(bookDetails.AvailableFrom);
            getBookResponse.Data.BookCategoryId.Should().Be(bookDetails.BookCategoryId);
            getBookResponse.Data.HasEBook.Should().Be(bookDetails.HasEBook);
            getBookResponse.Data.Id.Should().Be(bookDetails.Id);
        }
    }
}