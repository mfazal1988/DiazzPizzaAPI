using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using MediatR;
using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Domain.Models.Entities;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Infrastructure.Persistence.Contexts;
using DPizza.Application.Interfaces;
using AutoFixture;
using DPizza.Application.Features.Products.Queries.GetProductById;
using DPizza.Domain.Models.Dtos;
using DPizza.Infrastructure.Resources.Services;
using DPizza.Application.DTOs;
using DPizza.Application.Helpers;

namespace DPizza.Application.Test
{
    public class ProductTest
    {
        private readonly Fixture _fixture;


        public ProductTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateUserCommandHandler_Should_Return_True()
        {
            var mediatorMock = new Mock<IMediator>();
            //var command = new CreateProductCommand { ProductCategoryId = 1, Name = "aa", Description = "aa", ImagePath = "aa", ProductDetails = new List<ProductDetail>() };
            var command = _fixture.Create<CreateProductCommand>();

            var productRepositoryMock = new Mock<IProductRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            productRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(new Product());
            unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(true);

            var handler = new CreateProductCommandHandler(productRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);            
        }

        [Fact]
        public async Task GetProductQueryHandler_Should_Return_ProductDto()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();          
            //var query = _fixture.Create<GetProductByIdQuery>();
            var query = _fixture.Build<GetProductByIdQuery>()
                     .With(q => q.Id, 1)
                     .Create();
            //var expectedProductDto = _fixture.Create<ProductDto>();

            var productRepositoryMock = new Mock<IProductRepository>();
           // productRepositoryMock.SetupGet(repo => repo.Id).Returns(1);
            var translatorMock = new Mock<ITranslator>();
            // var translatorMessage = _fixture.Create<TranslatorMessage>();

            //productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(query.Id).ReturnsAsync(new Product());
            productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(query.Id));
            //translatorMock.Setup(uow => uow.GetString(_fixture.Create<TranslatorMessage>())).ReturnsAsync(true);

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object, translatorMock.Object);

            var product = _fixture.Create<Domain.Models.Entities.Product>();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.Success); // only select product id = 1 record
            Assert.NotNull(result.Data);
        }
    }
}