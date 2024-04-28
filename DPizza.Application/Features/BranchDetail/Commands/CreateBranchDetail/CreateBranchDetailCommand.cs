using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Collections.Generic;

namespace DPizza.Application.Features.BranchDetail.Commands.CreateBranchDetail
{
    public class CreateBranchDetailCommand : IRequest<BaseResult<long>>
    {
        public string Number { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }

    }
}
