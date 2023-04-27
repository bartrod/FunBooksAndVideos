using MediatR;
using ShawBrook.Application.Responses;
using ShawBrook.Core.Models;

namespace ShawBrook.Application.Commands
{
    public record CreatePurchaseOrderCommand(long CustomerId, ICollection<LineItemDto> lineItems) : IRequest<PurchaseOrderResponse>
    {
        public ICollection<Guid> GetProducts()
        {
            return lineItems.Where(x => x.ProductId != null).Select(x => x.ProductId!.Value).Distinct().ToList();
        }
        public ICollection<Guid> GetMemberships()
        {
            return lineItems.Where(x => x.MembershipId != null).Select(x => x.MembershipId!.Value).Distinct().ToList();
        }
    }
}
