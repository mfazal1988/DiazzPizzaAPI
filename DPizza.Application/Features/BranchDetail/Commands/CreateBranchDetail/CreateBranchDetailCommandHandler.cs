
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.BranchDetail.Commands.CreateBranchDetail
{
    public class CreateBranchDetailCommandHandler(IBranchDetailRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateBranchDetailCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateBranchDetailCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Models.Entities.BranchDetail(request.Number, request.Address1, request.Address2, request.City, request.ContactNumber);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }
}
