using ApiSaas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSaas.Data // ⚠️ TEM QUE bater com seu projeto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
    }
}