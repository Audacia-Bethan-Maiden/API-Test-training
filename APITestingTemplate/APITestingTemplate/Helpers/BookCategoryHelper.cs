using System;
using System.Collections.Generic;
using System.Net;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;

namespace APITestingTemplate.Helpers
{
    public class BookCategoryHelper : ApiTestsBase, IDisposable
    {
        private Random Random { get; } = new();

        public GetBookCategoryDto AddBookCategory()
        {
            // Set up the request to add the category
            var addCategoryRequest = SetupWithoutSave<AddBookCategoryRequest>();

            // Call the API to add the category
            var addCategoryResponse =
                Post<GetBookCategoryDtoCommandResult>(addCategoryRequest, Resources.AddBookCategory);

            // Check the status code is created
            addCategoryResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Return the data
            return new GetBookCategoryDto()
            {
                Name = addCategoryResponse.Data.Output.Name,
                Id = addCategoryResponse.Data.Output.Id
            };
        }

        public List<GetBookCategoryDto> AddManyBookCategories(int numberOfCategories)
        {
            // Empty list to store the book categories
            var bookCategoriesList = new List<GetBookCategoryDto>();

            for (int i = 0; i < numberOfCategories; i++)
            {
                // Add the category to the list
                bookCategoriesList.Add(AddBookCategory());
            }
            // Return the data
            return bookCategoriesList;
        }

        public void DeleteBookCategory(int bookCategoryId)
        {
            // Call the API to delete the category
            var deleteBookCategoryResponse =
                Delete<GetBookCategoryDtoCommandResult>(bookCategoryId, Resources.DeleteABookCategory);

            deleteBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public void DeleteManyBookCategories(List<GetBookCategoryDto> bookCategoryList)
        {
            foreach (var category in bookCategoryList)
            {
                DeleteBookCategory(category.Id);
            }
        }
    }
}