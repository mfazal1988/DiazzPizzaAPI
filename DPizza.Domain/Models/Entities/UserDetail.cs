using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class UserDetail : AuditableBaseEntity
    {
        private UserDetail()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserDetail(Guid userId, int userTypeId, string firstName, string lastName, string address, string city, string contactNumber)
        {
            UserId = userId;
            UserTypeId = userTypeId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            ContactNumber = contactNumber;
        }
        public Guid UserId { get;  set; }
        public int UserTypeId { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Address { get;  set; }
        public string City { get;  set; }
        public string ContactNumber { get;  set; }
       
    public void Update(long id,Guid userId, int userTypeId, string firstName, string lastName, string address, string city, string contactNumber,bool isDeleted)
        {
            Id = id;
            UserId = userId;
            UserTypeId = userTypeId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            ContactNumber = contactNumber;
            IsDeleted = isDeleted;
        }
    }
}
