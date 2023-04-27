using ShawBrook.Application.Commands;
using ShawBrook.Application.Services.Interfaces;

namespace ShawBrook.Application.Services
{
    internal class PurchaseOrderService : IPurchaseOrderService
    {
        public Task<long> CreateOrder(CreatePurchaseOrderCommand order)
        {
            // create order
            return Task.FromResult(10l);
        }
    }
}
