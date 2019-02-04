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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Ordem> Ordens { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}
