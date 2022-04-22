using Catalog_API.Dtos;
using Catalog_API.Entities;
using static Catalog_API.Dtos.Dtos;

namespace Catalog_API.Extensions 
{ 
    public static class DTOExtensions
    {
        public static ItemDto GetItemAsDTO(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
