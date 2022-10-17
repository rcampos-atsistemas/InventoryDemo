using Inventory.Api.Application.Commands;
using Inventory.Api.Application.DTOs;
using Inventory.Api.Application.Queries;
using Inventory.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net;

namespace Inventory.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InventoryController> _logger;
        private readonly IItemQueries _itemQueries;

        public InventoryController(ILogger<InventoryController> logger,IMediator mediator, IItemQueries itemQueries)
        {
            _mediator = mediator;
            _logger = logger;
            _itemQueries = itemQueries;
        }

        [Route("additem")]
        [HttpPost]
        public async Task<ActionResult<bool>> CreateItemDataAsync([FromBody] CreateItemDTO createItemCommandDTO)
        {
            return await _mediator.Send(
                new CreateItemCommand(){
                    Code = createItemCommandDTO.Code,
                    ExpirationDate = createItemCommandDTO.ExpirationDate,
                    Name = createItemCommandDTO.Name,
                    UnitPrice = createItemCommandDTO.UnitPrice,
                    Units = createItemCommandDTO.Units
                });
            
        }

        [Route("getitem")]
        [HttpGet]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetItemAsync(string itemName)
        {
            try
            {
                var item = await _itemQueries.GetItemAsync(itemName);

                return Ok(item);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
