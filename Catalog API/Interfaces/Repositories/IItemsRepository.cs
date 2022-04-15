using Catalog_API.Entities;
using System;
using System.Collections.Generic;

namespace Catalog_API.Interfaces.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}