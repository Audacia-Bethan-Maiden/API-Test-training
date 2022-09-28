using System;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api.DataSetup;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations
{
    [DefaultCustomization]
    public class BaseCustomizationsAddBook : ICustomization
    {
        private Random Random { get; } = new();

        public void Customize(IFixture fixture)
        {
            // Books
            fixture.Register(() => 
                AddBooks(fixture).Create());
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


    }
}
