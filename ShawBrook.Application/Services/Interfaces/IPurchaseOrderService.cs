using ShawBrook.Application.Commands;

namespace ShawBrook.Application.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        public Task<long> CreateOrder(CreatePurchaseOrderCommand order);
    }
}
