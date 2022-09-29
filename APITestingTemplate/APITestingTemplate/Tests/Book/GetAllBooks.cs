using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Books
{
    public class GetAllBooks : ApiTestsBase, IClassFixture<AddManyBooksAndCategoriesFixture>
    {
        private Random Random { get; } = new();
        private readonly AddManyBooksAndCategoriesFixture _addManyBooksAndCategoriesFixture;

        public GetAllBooks(AddManyBooksAndCategoriesFixture addManyBooksAndCategoriesFixture)
        {
            _addManyBooksAndCategoriesFixture = addManyBooksAndCategoriesFixture;
        }

        [Trait("Category", "Not Core")]
        [Fact]
        public void Scenario_2_As_a_user_I_can_get_all_books()
        {
            // Get book details
            var bookOneDetails = _addManyBooksAndCategoriesFixture.BookDataList[0].BookData;
            var bookOneTitle = bookOneDetails.First().Title;
            var bookTwoDetails = _addManyBooksAndCategoriesFixture.BookDataList[1].BookData;
            var bookTwoTitle = bookTwoDetails.First().Title;
            // Call the API to get all the books
            var getAllBooksResponse = GetAll<List<GetBookDto>>(Resources.GetAllBooks);

            // Check the status code is OK
            getAllBooksResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check some of the books are there
            getAllBooksResponse.Data?.Last().Title.Should().Be(bookTwoTitle);
            getAllBooksResponse.Data?[getAllBooksResponse.Data.Count - 2].Title.Should().Be(bookOneTitle);
        }
    }
}

