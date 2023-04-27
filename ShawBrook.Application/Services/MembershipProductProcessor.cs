using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;
using ShawBrook.Application.Services.Interfaces;

namespace ShawBrook.Application.Services
{
    public class MembershipProductProcessor : IProductProcessor
    {
        public async Task<ProductProcessorLineItemResponse> ProcessAsync(CreatePurchaseOrderCommand command)
        {
            if(command.GetMemberships().Any())
            {
                // Activate or handle failure
                return new ProductProcessorLineItemResponse()
                {
                    IsMembershipActivated = true,
                    IsShippingSlipGenerated = false,
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
