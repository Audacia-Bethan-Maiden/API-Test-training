using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDtos;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{
    public class AddManyBooksWithTheSameCategoryFixture : ApiTestsBase, IDisposable
    {
        public List<AddBookAndCategoryData> BookDataList { get; }

        public AddManyBooksWithTheSameCategoryFixture()
        {
            using var bookHelper = new BookHelper();
            BookDataList = bookHelper.AddManyBooksWithSameCategory(2);
        }

        public void Dispose()
        {
            using var bookHelper = new BookHelper();

            bookHelper.DeleteManyBooks(BookDataList);
        }
    }
}
