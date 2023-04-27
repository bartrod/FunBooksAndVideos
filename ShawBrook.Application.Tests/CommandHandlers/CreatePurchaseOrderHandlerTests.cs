using AutoFixture;
using Moq;
using ShawBrook.Application.CommandHandlers;
using ShawBrook.Application.Commands;
using ShawBrook.Application.Responses;
using ShawBrook.Application.Services;
using ShawBrook.Application.Services.Interfaces;
using ShawBrook.Core.Models;

namespace ShawBrook.Application.Tests.CommandHandlers
{
    public class CreatePurchaseOrderHandlerTests
    {
        private readonly CreatePurchaseOrderHandler _sut;
        private readonly Mock<IPurchaseOrderProcessor> _purchaseOrderProcessorMock;
        private readonly Mock<IPurchaseOrderService> _purchaseOrderServiceMock;

        private readonly Fixture _fixture;

        public CreatePurchaseOrderHandlerTests()
        {
            _purchaseOrderProcessorMock = new Mock<IPurchaseOrderProcessor>();
            _purchaseOrderServiceMock = new Mock<IPurchaseOrderService>();
            _sut = new CreatePurchaseOrderHandler(_purchaseOrderProcessorMock.Object, _purchaseOrderServiceMock.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_CreatePurchaseOrderCommand_When_ProcessorsAreSuccessufllyFinished_Then_VerifyProcessorExecution()
        {
            var createPurchaseOrderCommand = new CreatePurchaseOrderCommand(_fixture.Create<long>(), _fixture.CreateMany<LineItemDto>(3).ToList());
            _purchaseOrderProcessorMock.Setup(x => x.Process(It.IsAny<CreatePurchaseOrderCommand>())).ReturnsAsync(new ProductProcessorResponse() { IsSuccess = true });
            await _sut.Handle(createPurchaseOrderCommand, It.IsAny<CancellationToken>());

            _purchaseOrderProcessorMock.Verify(x => x.Process(It.Is<CreatePurchaseOrderCommand>(i => i == createPurchaseOrderCommand)), Times.Once);
        }

        [Fact]
        public async Task Handle_CreatePurchaseOrderCommand_When_ProcessorsAreSuccessufllyFinished_Then_VerifyOrderCreationService()
        {
            var createPurchaseOrderCommand = new CreatePurchaseOrderCommand(_fixture.Create<long>(), _fixture.CreateMany<LineItemDto>(3).ToList());
            _purchaseOrderProcessorMock.Setup(x => x.Process(It.IsAny<CreatePurchaseOrderCommand>())).ReturnsAsync(new ProductProcessorResponse() { IsSuccess = true });
            await _sut.Handle(createPurchaseOrderCommand, It.IsAny<CancellationToken>());

            _purchaseOrderServiceMock.Verify(x => x.CreateOrder(It.Is<CreatePurchaseOrderCommand>(i=>i == createPurchaseOrderCommand)), Times.Once);
        }
    }
}
