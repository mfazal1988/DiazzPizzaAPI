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
   
        public string Number { get;  set; }
        public string Address1 { get;  set; }
        public string Address2 { get;  set; }
        public string City { get;  set; }
        public string ContactNumber { get;  set; }
       
    public void Update(long id, string number, string address1, string address2, string city, string contactNumber, bool isDeleted)
        {
            Id = id;
            Number = number;
            Address1 = address1;
            Address2 = address2;
            City = city;
            ContactNumber = contactNumber;
            IsDeleted = isDeleted;
        }
    }
}
