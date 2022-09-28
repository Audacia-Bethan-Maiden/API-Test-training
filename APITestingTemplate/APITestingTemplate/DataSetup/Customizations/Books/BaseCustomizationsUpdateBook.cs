using System;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations.Books;

public class BaseCustomizationsUpdateBook : ICustomization
{
    private Random Random { get; } = new();
    public void Customize(IFixture fixture)
    {
        // Books
        fixture.Register(() => UpdateBook(fixture).Create());
    }

    // Books
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
}