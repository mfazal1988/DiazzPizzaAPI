using DPizza.Domain.Common;
using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class BranchDetailDto : AuditableBaseEntity
    {
        public BranchDetailDto()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BranchDetailDto(BranchDetail branchDetail)
        {
            Id = branchDetail.Id;
            Number = branchDetail.Number;
            Address1 = branchDetail.Address1;
            Address2 = branchDetail.Address2;
            City = branchDetail.City;
            ContactNumber = branchDetail.ContactNumber;
            IsDeleted = branchDetail.IsDeleted;
        }

        //public long Id { get; set; }
        public string Number { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
