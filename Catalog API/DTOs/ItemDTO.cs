using System;

namespace Catalog_API.DTOs
{
    public record ItemDTO
    {
        /// <summary>
        /// The <see cref="Guid"/> indentifier of the <see cref="Item"/>
        /// </summary>
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
