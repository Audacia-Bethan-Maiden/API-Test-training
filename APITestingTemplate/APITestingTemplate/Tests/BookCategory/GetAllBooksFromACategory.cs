using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;
namespace APITestingTemplate.Tests.BookCategory;

public class GetAllBooksFromACategory : ApiTestsBase, IClassFixture<AddManyBooksWithTheSameCategoryFixture>
{
    private readonly AddManyBooksWithTheSameCategoryFixture _addManyBooksWithTheSameCategoryFixture;

    public GetAllBooksFromACategory(AddManyBooksWithTheSameCategoryFixture addManyBooksWithTheSameCategoryFixture)
    {
        _addManyBooksWithTheSameCategoryFixture = addManyBooksWithTheSameCategoryFixture;
    }
    [Trait("Category", "Core")]
    [Fact]
    public void Scenario_5_As_a_user_I_can_get_all_books_from_a_category()
    {
        // Get book details
        var addedBooksList = _addManyBooksWithTheSameCategoryFixture.BookDataList;

        // Get the book category data
        var bookCategoryData = _addManyBooksWithTheSameCategoryFixture.BookDataList[0].BookCategoryData;
        var bookCategoryId = bookCategoryData.First().Id;

        // Call API to get all the book categories
        var bookCategoriesResponse = GetAll<GetBookDtoIEnumerableCommandResult>(Resources.GetBooksFromCategory(bookCategoryId.ToString()));

        // Check the status code
        bookCategoriesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Check books are from the right category
        for (int i = 0; i < addedBooksList.Count; i++)
        {
            // Set the book title for the book at element i
            var bookTitleAtI = addedBooksList[i].BookData.First().Title;

            // Check the book category Id and Title of the book at i
            bookCategoriesResponse.Data?.Output.ElementAt(i).BookCategoryId.Should().Be(bookCategoryId);
            bookCategoriesResponse.Data?.Output.ElementAt(i).Title.Should().Be(bookTitleAtI);
        }
    }
}