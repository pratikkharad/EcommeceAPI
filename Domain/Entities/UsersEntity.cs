﻿using Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsersEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativeEmail { get; set; }
        public string Address { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}
