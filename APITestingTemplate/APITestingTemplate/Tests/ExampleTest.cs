using System.Net;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;


namespace APITestingTemplate.Tests
{
    public class 
        
        ExampleTests : ApiTestsBase
    {

        [Fact]
        public void Scenario_1_As_a_user_I_can_get_a_book_by_its_Id()
        {
            // Set the bookId you wish to get
            var bookId = Constants.TheManWhoDiedTwiceBookID;

            // Call the get API to get the book by its ID
            var getBookResponse = Get<Book>(bookId, Resources.GetBookById);

            // Check the status code is ok
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check that the correct book is returned
            getBookResponse.Data.Title.Should().Be("The Man Who Died Twice");
            getBookResponse.Data.Author.Should().Be("Richard Osman");
        }
    }
}