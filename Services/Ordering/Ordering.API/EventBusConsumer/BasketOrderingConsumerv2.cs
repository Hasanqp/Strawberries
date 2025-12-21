using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Commands;

namespace Ordering.API.EventBusConsumer
{
    public class BasketOrderingConsumerv2 : IConsumer<BasketCheckoutEventv2>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketOrderingConsumer> _logger;
        public BasketOrderingConsumerv2(IMediator mediator, IMapper mapper, ILogger<BasketOrderingConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<BasketCheckoutEventv2> context)
        {
            using var scope = _logger.BeginScope("Handling cart checkout event for {correlationId}", context.Message.CorrelationId);
            try
            {
                var cmd = _mapper.Map<CheckoutOrderCommandv2>(context.Message);
                var result = await _mediator.Send(cmd);
                _logger.LogInformation("Cart checkout event completed successfully!!!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "An error occurred while processing the BasketCheckoutEvent. CorrelationId: {CorrelationId}", context.Message.CorrelationId);
                throw;
            }
        }
    }
}
