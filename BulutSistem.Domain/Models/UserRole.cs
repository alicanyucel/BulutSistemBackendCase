﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulutSistem.Domain.Models
{
    public sealed class UserRole
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
