using APITestingTemplate.Models.Dtos;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations.Books;

public class AddBookWithTestTitle : BaseCustomizations
{
    protected override IPostprocessComposer<AddBookRequest> AddBooks(IFixture fixture)
    {
        return base.AddBooks(fixture).With(b => b.Title, () => "Test Title");
    }
}