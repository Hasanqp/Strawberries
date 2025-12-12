namespace Ordering.Core.Common
{
    public abstract class EntitiyBase
    {
        // Protected set is made to use in the derived classes
        public int Id { get; protected set; }
        // Belo properties are audit properties
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
