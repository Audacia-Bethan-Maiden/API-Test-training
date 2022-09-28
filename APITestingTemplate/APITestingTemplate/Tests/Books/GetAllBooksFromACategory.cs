using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;
namespace APITestingTemplate.Tests.Books;

public class GetAllBooksFromACategory : ApiTestsBase, IClassFixture<AddManyBooksWithTheSameCategoryFixture>
{
    private readonly AddManyBooksWithTheSameCategoryFixture _addManyBooksWithTheSameCategoryFixture;

    public GetAllBooksFromACategory(AddManyBooksWithTheSameCategoryFixture addManyBooksWithTheSameCategoryFixture)
    {
        _addManyBooksWithTheSameCategoryFixture = addManyBooksWithTheSameCategoryFixture;
    }
    [Fact]
    public void Scenario_5_As_a_user_I_can_get_all_books_from_a_category()
    {
        // Get book details
        var bookOneDetails = _addManyBooksWithTheSameCategoryFixture.BookDataList[0].BookData;
        var bookTwoDetails = _addManyBooksWithTheSameCategoryFixture.BookDataList[1].BookData;

        // Get the book category data
        var bookCategoryData = _addManyBooksWithTheSameCategoryFixture.BookDataList[0].BookCategoryData;
        var bookCategoryId = bookCategoryData.First().Id;

        // Call API to get all the book categories
        var bookCategoriesResponse = GetAll<List<GetBookDtoIEnumerableCommandResult>>(Resources.GetBooksFromCategory(bookCategoryId.ToString()));

        // Check the status code
        bookCategoriesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Check books are from the right category
        bookCategoriesResponse.Content.Should().Contain(bookOneDetails.First().Title);
        bookCategoriesResponse.Content.Should().Contain(bookTwoDetails.First().Title);
    }
}