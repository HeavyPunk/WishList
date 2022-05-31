using Microsoft.AspNetCore.Identity;

namespace Wishlist.Entities;

public class User : IdentityUser
{
    public Guid Id { get; set; }
}