using System;

namespace Domain.Entities.Identity
{
    public class ApplicationUserLogin
    {
        public Guid Id { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
