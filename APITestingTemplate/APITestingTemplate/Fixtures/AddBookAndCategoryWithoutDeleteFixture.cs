using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{
    public class AddBookAndCategoryWithoutDeleteFixture: ApiTestsBase
    {
        public AddBookAndCategoryData BookData { get; }

        public AddBookAndCategoryWithoutDeleteFixture()
        {
            using var bookHelper = new BookHelper();

            BookData = bookHelper.AddBookWithNewCategory();
        }
    }
}
