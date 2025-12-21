using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Core.Entities;
using Ordering.Core.Ripositories;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderCommandv2Handler :IRequestHandler<CheckoutOrderCommandv2, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandv2Handler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CheckoutOrderCommandv2 request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var generatedOrder = await _orderRepository.AddAsync(orderEntity);
            _logger.LogInformation($"Order with Id {generatedOrder.Id} successfully created with V2 Handler");
            return generatedOrder.Id;
        }
    }
}
