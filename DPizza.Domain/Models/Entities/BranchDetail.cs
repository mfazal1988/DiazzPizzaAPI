using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class BranchDetail : AuditableBaseEntity
    {
        private BranchDetail()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BranchDetail(string number, string address1, string address2, string city, string contactNumber)
        {
            Number = number;
            Address1 = address1;
            Address2 = address2;
            City = city;
            ContactNumber = contactNumber;
        }
   
        public string Number { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string City { get; private set; }
        public string ContactNumber { get; private set; }
       
    public void Update(string number, string address1, string address2, string city, string contactNumber, bool isDeleted)
        {
            Number = number;
            Address1 = address1;
            Address2 = address2;
            City = city;
            ContactNumber = contactNumber;
            IsDeleted = isDeleted;
        }
    }
}
