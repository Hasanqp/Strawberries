using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Commands;

namespace Ordering.API.EventBusConsumer
{
    public class BasketOrderingConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketOrderingConsumer> _logger;

        public BasketOrderingConsumer(IMediator mediator, IMapper mapper, ILogger<BasketOrderingConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            
            using var scope = _logger.BeginScope("Обработка события оформления корзины для {correlationId}", context.Message.CorrelationId);
            try
            {
                var cmd = _mapper.Map<CheckoutOrderCommand>(context.Message);
                var result = await _mediator.Send(cmd);
                _logger.LogInformation("Событие оформления корзины успешно завершено!!!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Произошла ошибка при обработке события BasketCheckoutEvent. CorrelationId: {CorrelationId}",
                    context.Message.CorrelationId);
                throw;
            }
        }
    }
}
