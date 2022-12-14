using System;
using APITestingTemplate.Models.Dtos;
using APITestingTemplate.Tests.BookCategory;
using Audacia.Random.Extensions;
using Audacia.Testing.Api.DataSetup;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations
{
    [DefaultCustomization]
    public class BaseCustomizations : ICustomization
    {
        private Random Random { get; } = new();

        public void Customize(IFixture fixture)
        {
            // Books
            fixture.Register(() => 
                AddBooks(fixture).Create());

            fixture.Register(() => 
                UpdateBook(fixture).Create());

            fixture.Register(()=> 
                AddBookCategory(fixture).Create());

            fixture.Register(() => 
                UpdateBookCategory(fixture).Create());
        }

        protected virtual IPostprocessComposer<AddBookRequest> AddBooks(IFixture fixture)
        {
            return fixture.Build<AddBookRequest>()
                .With(dto => dto.Title, () => Random.Words(2))
                .With(dto => dto.Description, () => Random.Sentence())
                .With(dto => dto.Author, () => Random.Forename() + ' ' + Random.Surname())
                .With(dto => dto.PublishedYear, () => 1984)
                .With(dto => dto.AvailableFrom, () => new DateTime(2020, 03, 20))
                .With(dto => dto.HasEBook, () => true)
                .With(dto => dto.BookCategoryId, () => 1);
        }

        protected virtual IPostprocessComposer<UpdateBookRequest> UpdateBook(IFixture fixture)
        {
            return fixture.Build<UpdateBookRequest>()
                .With(dto => dto.Title, () => Random.Words(2))
                .With(dto => dto.Description, () => Random.Sentence())
                .With(dto => dto.Author, () => Random.Forename() + ' ' + Random.Surname())
                .With(dto => dto.AvailableFrom, () => new DateTime(1964, 03, 20))
                .With(dto => dto.PublishedYear, () => 1999)
                .With(dto => dto.HasEBook, () => true)
                .With(dto => dto.BookCategoryId, () => 2);
        }

        protected virtual IPostprocessComposer<AddBookCategoryRequest> AddBookCategory(IFixture fixture)
        {
            return fixture.Build<AddBookCategoryRequest>()
                .With(dto => dto.Name, () => Random.Words(2));
        }

        protected virtual IPostprocessComposer<UpdateBookCategoryRequest> UpdateBookCategory(IFixture fixture)
        {
            return fixture.Build<UpdateBookCategoryRequest>()
                .With(dto => dto.Name, () => Random.Words(2));
        }
    }
}
