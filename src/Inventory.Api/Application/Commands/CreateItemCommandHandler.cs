using Inventory.Api.Application.Queries;
using Inventory.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.Serialization;

namespace Inventory.Api.Application.Commands
{
   
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CreateItemCommandHandler> _logger;
        private readonly IItemRepository _itemRepository;
              
        public CreateItemCommandHandler(IMediator mediator, ILogger<CreateItemCommandHandler> logger, IItemRepository itemRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var itemToAdd = new Item(request.Name, request.UnitPrice, request.ExpirationDate, request.Code, request.Units);

            _logger.LogInformation("Creating Item - Order: {@Order}", itemToAdd);
            
            _itemRepository.Add(itemToAdd);

            return await _itemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }

}
