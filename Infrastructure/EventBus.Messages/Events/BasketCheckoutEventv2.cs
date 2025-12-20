namespace EventBus.Messages.Events
{
    public class BasketCheckoutEventv2 : BaseIntegrationEvent
    {
        public string? UserName { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
