using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;
using ShawBrook.Application.Services.Interfaces;

namespace ShawBrook.Application.Services
{
    public class PhysicalProductProcessor : IProductProcessor
    {
        public async Task<ProductProcessorLineItemResponse> ProcessAsync(CreatePurchaseOrderCommand command)
        {
            if (command.GetProducts().Any())
            {
                // Activate or handle failure
                return new ProductProcessorLineItemResponse()
                {
                    IsMembershipActivated = false,
                    IsShippingSlipGenerated = true,
                    IsSuccess = true
                };
            }

            return new ProductProcessorLineItemResponse()
            {
                IsMembershipActivated = false,
                IsShippingSlipGenerated = false,
                IsSuccess = true
            };
        }
    }
}
