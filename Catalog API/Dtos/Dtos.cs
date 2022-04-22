using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog_API.Dtos
{
    /// <summary>
    /// Static class for Dtos
    /// </summary>
    public static class Dtos
    {
        /// <summary>
        /// <see cref="record"/> A standard Dto for passing <see cref="Item"/>s results out of the API.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <param name="CreatedDate"></param>
        public record ItemDto (Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
        /// <summary>
        /// <see cref="record"/> A Dto used to create new <see cref="Item"/>s
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        public record CreateItemDto ([Required] string Name, string Description, [Range(1, 1000)]decimal Price);
        /// <summary>
        /// <see cref="record"/> A Dto used to update existing <see cref="Item"/>s
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        public record UpdateItemDto ([Required] string Name, string Description, [Range(1, 1000)]decimal Price);
    }
}
