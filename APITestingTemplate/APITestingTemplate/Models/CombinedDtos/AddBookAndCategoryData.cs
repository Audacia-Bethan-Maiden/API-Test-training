using System.Collections;
using System.Collections.Generic;
using APITestingTemplate.Models.Dtos;

namespace APITestingTemplate.Models.CombinedDtos
{
    public class AddBookAndCategoryData
    {
        // Dtos to use can be found on the swagger page
        // Book category data
        public ICollection<GetBookCategoryDto> BookCategoryData { get; set; } = new List<GetBookCategoryDto>();

        // Book information
        public ICollection<GetBookDto> BookData { get; set; } = new List<GetBookDto>();
    }
}