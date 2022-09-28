using APITestingTemplate.Models.Dtos;
using System.Collections.Generic;

namespace APITestingTemplate.Models.CombinedDtos
{
    public class AddCategoryData
    {
        // Book category data
        public ICollection<GetBookCategoryDtoCommandResult> BookData { get; set; } = new List<GetBookCategoryDtoCommandResult>();
        // Book category data
        public ICollection<GetBookCategoryDto> BookCategoryData { get; set; } = new List<GetBookCategoryDto>();
    }
}