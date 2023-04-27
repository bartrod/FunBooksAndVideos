using MediatR;
using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;
using ShawBrook.Application.Services.Interfaces;

namespace ShawBrook.Application.CommandHandlers
{
    public class CreatePurchaseOrderHandler : IRequestHandler<CreatePurchaseOrderCommand, PurchaseOrderResponse>
    {
        private readonly IPurchaseOrderProcessor _purchaceOrderProcessor;
        private readonly IPurchaseOrderService _purchaseOrderService;

        public CreatePurchaseOrderHandler(IPurchaseOrderProcessor purchaceOrderProcessor, IPurchaseOrderService purchaseOrderService)
        {
            _purchaceOrderProcessor = purchaceOrderProcessor;
            _purchaseOrderService = purchaseOrderService;
        }
        public async Task<PurchaseOrderResponse> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _purchaceOrderProcessor.Process(request);

            if (result.IsSuccess)
            {
                // create order
                var createOrderResult = await _purchaseOrderService.CreateOrder(request);
                return new PurchaseOrderResponse(createOrderResult, true);
            }

            return new PurchaseOrderResponse(0, false);
        }
    }
}
