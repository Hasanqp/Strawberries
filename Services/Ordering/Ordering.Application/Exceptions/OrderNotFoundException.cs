namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : ApplicationException
    {
        public OrderNotFoundException(string name, object key) : base($"Сущность {name} с идентификатором {key} не найдена.")
        {

        }
    }
}
