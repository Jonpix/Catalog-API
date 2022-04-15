using Catalog_API.DTOs;
using Catalog_API.Entities;

namespace Catalog_API.Extensions 
{ 
    public static class DTOExtensions
    {
        public static ItemDTO GetItemAsDTO(this Item item)
        {
            return new ItemDTO
            {
                Name = item.Name,
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                Price = item.Price,
            };
        }
    }
}
