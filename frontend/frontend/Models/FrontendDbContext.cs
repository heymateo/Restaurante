using Microsoft.EntityFrameworkCore;

namespace frontend.Models
{
    public class FrontendDbContext : DbContext
    {
        public FrontendDbContext(DbContextOptions<FrontendDbContext> options) : base(options) { }
        public DbSet<AdministradorModel> Administrador { get; set; }
        public DbSet<EmpleadoModel> Empleado { get; set; }
        public DbSet<ChefModel> Chef { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<CuentaModel> Cuenta { get; set; }
        public DbSet<MesaModel> Mesa { get; set; }
        public DbSet<PlatilloModel> Platillo { get; set; }
        public DbSet<BebidaModel> Bebida { get; set; }
        public DbSet<OrdenModel> Orden { get; set; }
        public DbSet<DetalleOrdenModel> DetalleOrden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("FrontendDbContext");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
