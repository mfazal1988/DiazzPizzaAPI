using DPizza.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace DPizza.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Created = DateTime.Now;
        }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        //public UserDetail UserDetail { get; set; }
    }
}
