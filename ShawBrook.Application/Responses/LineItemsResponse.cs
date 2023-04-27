namespace ShawBrook.Application.Responses
{
    public record LineItemResponse(
        string Name,
        Guid MembershipId,
        Guid ProductId,
        int Quantity);
}
