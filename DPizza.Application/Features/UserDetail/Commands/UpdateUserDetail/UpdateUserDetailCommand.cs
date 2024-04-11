using DPizza.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Commands.UpdateUserDetail
{
    public class UpdateUserDetailCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
        public Guid UserId { get; set; } // this is from identity provider
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
