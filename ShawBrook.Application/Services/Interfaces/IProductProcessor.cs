using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;

namespace ShawBrook.Application.Services.Interfaces
{
    public interface IProductProcessor
    {
        Task<ProductProcessorLineItemResponse> ProcessAsync(CreatePurchaseOrderCommand command);
    }
}
