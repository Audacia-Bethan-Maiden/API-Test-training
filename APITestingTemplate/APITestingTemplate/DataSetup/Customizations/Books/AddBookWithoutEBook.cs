using APITestingTemplate.Models.Dtos;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations.Books
{
    public class AddBookWithoutEBook : BaseCustomizations
    {
        protected override IPostprocessComposer<AddBookRequest> AddBooks(IFixture fixture)
        {
            return base.AddBooks(fixture).With(b => b.HasEBook, () => false);
        }
    }
}