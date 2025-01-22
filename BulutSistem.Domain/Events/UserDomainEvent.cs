
using BulutSistem.Domain.Models;
using MediatR;

namespace BulutSistem.Domain.Events
{
    public sealed class UserDomainEvent : INotification
    {
        public AppUser AppUser { get; }

        public UserDomainEvent(AppUser appUser)
        {
            AppUser = appUser;
        }
    }
}
