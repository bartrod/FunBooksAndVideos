namespace ShawBrook.Core.Models
{
    public class LineItemDto
    {
        public string Name { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? MembershipId { get; set; }
        public decimal Price { get; set; }
    }
}
