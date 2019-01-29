using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreMvcEcommerce
{
    public class Cliente : IdentityUser
    {
        public string Nome { get; set; }

       // public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Cliente> manager)
       // {
       //     var userIdentity = await  .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
       //     return userIdentity;
       // }
    }
}