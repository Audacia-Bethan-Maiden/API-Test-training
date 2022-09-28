using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{
    public class AddManyCategoriesFixture : ApiTestsBase, IDisposable
    {
        public List<GetBookCategoryDto> BookCategoryDataList { get; }

        public AddManyCategoriesFixture()
        {
            using var bookCategoryHelper = new BookCategoryHelper();

            BookCategoryDataList = bookCategoryHelper.AddManyBookCategories(2);
        }
        public void Dispose()
        {
            using var bookCategoryHelper = new BookCategoryHelper();

            bookCategoryHelper.DeleteManyBookCategories(BookCategoryDataList);
        }
    }
}
