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
    public class AddManyBooksAndCategoriesFixture : ApiTestsBase, IDisposable
    {
        public List<AddBookAndCategoryData> BookDataList { get; }

        public AddManyBooksAndCategoriesFixture()
        {
            using var bookHelper = new BookHelper();

            BookDataList = bookHelper.AddManyBooksWithCategories(2);
        }

        public void Dispose()
        {
            using var bookHelper = new BookHelper();

            bookHelper.DeleteManyBooksAndCategories(BookDataList);
        }
    }
}
