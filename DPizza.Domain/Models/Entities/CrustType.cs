using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace DPizza.Domain.Models.Entities
{
    public class CrustType
    {
        private CrustType()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CrustType(int id, string name, string description, bool isDeleted)
        {
            Id = id;
            Name = name;
            Description = description;
            IsDeleted = isDeleted;
        }
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public bool IsDeleted { get;  set; }

        public void Update(int id, string name, string description, bool isDeleted)
        {
            Id = id;
            Name = name;
            Description = description;
            IsDeleted = isDeleted;
        }
    }
}
