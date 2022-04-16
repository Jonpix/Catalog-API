using Catalog_API.Entities;
using Catalog_API.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_API.Repositories
{
    public class InMemoryItemsRepository : IItemsRepository
    {
        private List<Item> items = new List<Item>()
        {
            new Item{ Id=Guid.NewGuid(), Name = "Potion", Price = 9 ,CreatedDate = DateTimeOffset.UtcNow },
            new Item{ Id=Guid.NewGuid(), Name = "Iron Sword", Price = 20 ,CreatedDate = DateTimeOffset.UtcNow },
            new Item{ Id=Guid.NewGuid(), Name = "Bronze Shield", Price = 18 ,CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.SingleOrDefault(x => x.Id == id);
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
