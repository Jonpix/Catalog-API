﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_API.Entities
{
    public record Item
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
