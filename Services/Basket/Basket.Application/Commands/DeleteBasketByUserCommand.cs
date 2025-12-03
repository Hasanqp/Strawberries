using MediatR;

namespace Basket.Application.Commands
{
    public class DeleteBasketByUserCommand : IRequest<Unit>
    {
        public string UserName { get; set; }
        public DeleteBasketByUserCommand(string userName)
        {
            UserName = userName;
        }
    }
}
