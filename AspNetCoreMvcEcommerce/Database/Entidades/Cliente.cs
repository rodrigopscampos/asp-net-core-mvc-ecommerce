using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreMvcEcommerce
{
    public class Cliente : IdentityUser
    {
        public string Nome { get; set; }

        public virtual ICollection<Ordem> Ordens {get;set;}
    }
}