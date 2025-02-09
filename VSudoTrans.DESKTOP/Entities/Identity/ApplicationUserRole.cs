﻿using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities.Identity
{
    public class ApplicationUserRole : IAudited
    {
        public Guid Id { get; set; }
        public virtual ApplicationUser? User { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual ApplicationRole? Role { get; set; }
        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
