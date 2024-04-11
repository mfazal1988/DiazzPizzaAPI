using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class UserDetailDto
    {
        public UserDetailDto()
        {
        }
        public UserDetailDto(UserDetail userDetail)
        {
            UserId = userDetail.UserId;
            UserTypeId = userDetail.UserTypeId;
            FirstName = userDetail.FirstName;
            LastName = userDetail.LastName;
            Address = userDetail.Address;
            City = userDetail.City;
            ContactNumber = userDetail.ContactNumber;
        }

        public Guid UserId { get; private set; } // this is from identity provider

        public int UserTypeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string ContactNumber { get; private set; }

    }
}
