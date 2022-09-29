using APITestingTemplate.Models.Dtos;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations.Books
{
    public class EditABookToHaveAnEBook : BaseCustomizations
    {
        protected override IPostprocessComposer<UpdateBookRequest> UpdateBook(IFixture fixture)
        {
            return base.UpdateBook(fixture).With(b => b.HasEBook, () => true);
        }
    }
}

