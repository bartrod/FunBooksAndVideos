using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;
using ShawBrook.Application.Services.Interfaces;

namespace ShawBrook.Application.Services
{
    public class PurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly IEnumerable<IProductProcessor> _productProcessors;
        public PurchaseOrderProcessor(IEnumerable<IProductProcessor> productProcessors)
        {
            _productProcessors = productProcessors;
        }
        public async Task<ProductProcessorResponse> Process(CreatePurchaseOrderCommand command)
        {
            var purchaseOrderResponse = new List<ProductProcessorLineItemResponse>();

            foreach (var processor in _productProcessors)
            {
                purchaseOrderResponse.Add(await processor.ProcessAsync(command));
            }

            if (purchaseOrderResponse.Any(x => !x.IsSuccess))
            {
                return new ProductProcessorResponse()
                {
                    IsSuccess = false
                };
            }

            return new ProductProcessorResponse()
            {
                IsSuccess = true
            };
        }
    }
}
