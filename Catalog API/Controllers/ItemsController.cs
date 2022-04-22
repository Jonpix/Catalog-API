using Catalog_API.Entities;
using Catalog_API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog_API.Extensions;
using Microsoft.Extensions.Logging;
using static Catalog_API.Dtos.Dtos;

namespace Catalog_API.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        private readonly ILogger<ItemsController> logger;
        public ItemsController(IItemsRepository injectedRepository, ILogger<ItemsController> logger)
        {
            repository = injectedRepository;
            this.logger = logger;
        }

        /// <summary>
        /// Gets <see cref="Item"/>s 
        /// </summary>
        /// <param name="name">Optional name for fuzzy matching.</param>
        /// <returns>All <see cref="Item"/>s unless a <see cref="name"/> is passed, then returns <see cref="Item"/>s with
        /// fuzzy matching <see cref="Item.Name"/></returns>
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync(string name = null)
        {
            var items = (await repository.GetItemsAsync())
                        .Select(item => item.GetItemAsDTO());

            if (!string.IsNullOrWhiteSpace(name))
            {
                items = items.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            logger.LogInformation($"{DateTimeOffset.UtcNow.ToString("hh:mm:ss")} Reteived {items.Count()} items");

            return items;
        }

        /// <summary>
        /// Gets a single <see cref="Item"/> by <see cref="Item.Id"/>
        /// </summary>
        /// <param name="id"><see cref="Guid"/> Id of required item.</param>
        /// <returns><see cref="ActionResult{ItemDto}"/></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.GetItemAsDTO();
        }

        /// <summary>
        /// Creates the given item.
        /// </summary>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDTO)
        {
            Item item = new Item() 
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.GetItemAsDTO());
        }

        /// <summary>
        /// Updates the <see cref="Item"/> with the given <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of the item to be updated.</param>
        /// <param name="itemDTO">Updates that will be applied to the item.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDTO)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Name = itemDTO.Name;
            existingItem.Description = itemDTO.Description;
            existingItem.Price = itemDTO.Price;

            await repository.UpdateItemAsync(existingItem);
            return NoContent();
        }

        
        /// <summary>
        /// Deletes the <see cref="Item"/> with the given <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            return NoContent();
        }

    }
}
