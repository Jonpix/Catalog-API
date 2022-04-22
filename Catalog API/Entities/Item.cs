using System;

namespace Catalog_API.Entities
{
    public class Item
    {
        /// <summary>
        /// The <see cref="Guid"/> indentifier of the <see cref="Item"/>
        /// </summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
