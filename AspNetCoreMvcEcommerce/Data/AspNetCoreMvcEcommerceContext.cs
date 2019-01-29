using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcEcommerce.Data
{
    public class AspNetCoreMvcEcommerceContext : IdentityDbContext
    {
        public AspNetCoreMvcEcommerceContext(DbContextOptions<AspNetCoreMvcEcommerceContext> options)
            : base(options)
        {
        }

        /*
        public AspNetCoreMvcEcommerceContext()
           : base("AspNetMvcEcommerce")
        {
        }

        public static AspNetCoreMvcEcommerceContext Create()
        {
            return new AspNetCoreMvcEcommerceContext();
        }
        */

        public virtual DbSet<Ordem> Ordens { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}
