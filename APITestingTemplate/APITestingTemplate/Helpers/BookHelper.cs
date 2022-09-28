using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Models.CombinedDtos;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;

namespace APITestingTemplate.Helpers
{
    public class BookHelper : ApiTestsBase
    {
        private  Random Random { get; } = new();

        // Constructor and private book category helper 
        private readonly BookCategoryHelper _bookCategoryHelper;

        public BookHelper()
        {
            _bookCategoryHelper = new BookCategoryHelper();
        }

        public AddBookAndCategoryData CreateBook(int bookCategoryId, string bookCategoryName)
        {
            // Set up the request to add the book
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

            // Set the book category Id and generate other details
            addBookRequest.BookCategoryId = bookCategoryId;
            addBookRequest.Title = Random.Words(2);
            addBookRequest.Description = Random.Sentence();
            addBookRequest.Author = Random.Forename() + ' ' + Random.Surname();
            addBookRequest.PublishedYear = 1982;
            addBookRequest.HasEBook = true;
            addBookRequest.AvailableFrom = new DateTime(2022, 03, 20);

            // Send the request to add the book
            var addBookResponse =
                Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook, null);
            // Check the correct response is returned
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            //Return the book values as the GetBookDto
            return new AddBookAndCategoryData()
            {
                BookData = new List<GetBookDto>()
                {
                    addBookResponse.Data.Output
                },
                BookCategoryData = new List<GetBookCategoryDto>()
                {
                    new GetBookCategoryDto()
                    {
                        Name = bookCategoryName,
                        Id = bookCategoryId
                    }
                }
            };
        }

        public AddBookAndCategoryData AddBookWithNewCategory()
        {
            var bookCategory = _bookCategoryHelper.AddBookCategory();

            return CreateBook(bookCategory.Id, bookCategory.Name);
        }

        public List<AddBookAndCategoryData> AddManyBooksWithSameCategory(int numberOfBooks)
        {
            var BookDataList = new List<AddBookAndCategoryData>();
            var bookCategory = _bookCategoryHelper.AddBookCategory();
            for (int i = 0; i < numberOfBooks; i++)
            {
                BookDataList.Add(CreateBook(bookCategory.Id, bookCategory.Name));
            }
            return BookDataList;
        }

        public List<AddBookAndCategoryData> AddManyBooksWithCategories(int numberOfBooks)
        {
            var BookDataList = new List<AddBookAndCategoryData>();
            for (int i = 0; i < numberOfBooks; i++)
            {
                var bookCategory = _bookCategoryHelper.AddBookCategory();

                BookDataList.Add(CreateBook(bookCategory.Id, bookCategory.Name));
            }
            return BookDataList;
        }

        public void DeleteManyBooksAndCategories(List<AddBookAndCategoryData> BookDataList)
        {
            foreach (var book in BookDataList)
            {
                DeleteBook(book.BookData.First().Id);

                _bookCategoryHelper.DeleteBookCategory(book.BookCategoryData.First().Id);
            }
        }

        public void DeleteBookAndCategory(int bookCategoryId, int bookId)
        {
            DeleteBook(bookId);

            _bookCategoryHelper.DeleteBookCategory(bookCategoryId);
        }


        public void DeleteBook(int bookId)
        {
            // Call the API to delete a book
            var deleteBookResponse = Delete(bookId, Resources.DeleteBook, null);

            // Check the correct response is returned
            deleteBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public void DeleteManyBooks(List<AddBookAndCategoryData> bookList)
        {
            foreach (var book in bookList)
            {
                DeleteBook(book.BookData.First().Id);
            }
        }
    }
}
