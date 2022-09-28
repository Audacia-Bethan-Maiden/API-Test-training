using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestingTemplate.Fixtures
{
    public class AddCategoryWithoutDeleteFixture
    {
        public GetBookCategoryDto BookCategoryData { get; }

        public AddCategoryWithoutDeleteFixture()
        {
            using var bookCategoryHelper = new BookCategoryHelper();

            BookCategoryData = bookCategoryHelper.AddBookCategory();
        }
    }
}
