using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;

namespace ShawBrook.Application.Services.Interfaces
{
    public interface IPurchaseOrderProcessor
    {
        Task<ProductProcessorResponse> Process(CreatePurchaseOrderCommand command);
    }
}
