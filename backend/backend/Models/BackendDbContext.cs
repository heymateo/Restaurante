using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class BackendDbContext : DbContext
    {
        public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options) { }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Chef> Chef { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Platillo> Platillo { get; set; }
        public DbSet<Bebida> Bebida { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("RestauranteDbContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relación uno a uno entre Orden y Cuenta
            modelBuilder.Entity<Cuenta>()
                .HasOne(o => o.Orden)
                .WithOne(c => c.Cuenta)
                .HasForeignKey<Cuenta>(c => c.Id_Orden);

            // Configurar relación muchos a uno entre Orden y Cliente
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Cliente)
                .WithMany()
                .HasForeignKey(d => d.Id_Cliente);

            // Configurar relación muchos a uno entre Orden y Chef
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Chef)
                .WithMany()
                .HasForeignKey(d => d.Id_Chef);

            // Configurar relación muchos a uno entre Orden y Empleado
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Empleado)
                .WithMany()
                .HasForeignKey(d => d.Id_Empleado);

            // Configurar relación uno a uno entre Orden y Mesa
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Mesa)
                .WithOne(m => m.Orden)
                .HasForeignKey<Mesa>(d => d.Id_Mesa);

            // Configurar relación uno a uno entre Orden y DetalleOrden
            modelBuilder.Entity<Orden>()
               .HasOne(o => o.DetalleOrden)
               .WithOne(d => d.Orden)
               .HasForeignKey<DetalleOrden>(d => d.Id_Detalle_Orden);

            // Configurar relación muchos a uno entre DetalleOrden y Platillo
            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Platillo)
                .WithMany()
                .HasForeignKey(d => d.Id_Platillo)
                .OnDelete(DeleteBehavior.Restrict); // Opción para NO ACTION;

            // Configurar relación muchos a uno entre DetalleOrden y Bebida
            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Bebida)
                .WithMany()
                .HasForeignKey(d => d.Id_Bebida)
                .OnDelete(DeleteBehavior.Restrict); // Opción para NO ACTION;

            // Configurar relación uno a muchos entre Platillo y Categoria
            modelBuilder.Entity<Platillo>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Platillos)
                .HasForeignKey(p => p.Id_Categoria);

            // Configurar relación uno a muchos entre Bebida y Categoria
            modelBuilder.Entity<Bebida>()
                .HasOne(b => b.Categoria)
                .WithMany(c => c.Bebidas)
                .HasForeignKey(b => b.Id_Categoria);

            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(new Administrador { Id_Administrador = 1, Nombre = "admin", Correo = "admin@gmail.com", Contrasena = "root", Activo = true });

            modelBuilder.Entity<Empleado>().HasData(
                new Empleado { Id_Empleado = 1, Nombre = "Juan Pérez", Correo = "juan.perez@gmail.com", Contrasena = "root", Activo = true },
                new Empleado { Id_Empleado = 2, Nombre = "María López", Correo = "maria.lopez@gmail.com", Contrasena = "root", Activo = true },
                new Empleado { Id_Empleado = 3, Nombre = "Carlos García", Correo = "carlos.garcia@gmail.com", Contrasena = "root", Activo = true },
                new Empleado { Id_Empleado = 4, Nombre = "Laura Martínez", Correo = "laura.martinez@gmail.com", Contrasena = "root", Activo = true },
                new Empleado { Id_Empleado = 5, Nombre = "Miguel Hernández", Correo = "miguel.hernandez@gmail.com", Contrasena = "root", Activo = true });

            modelBuilder.Entity<Chef>().HasData(
                new Chef { Id_Chef = 1, Nombre = "Ana Rodríguez", Correo = "ana.rodriguez@gmail.com", Contrasena = "root", Activo = true },
                new Chef { Id_Chef = 2, Nombre = "Pedro Gómez", Correo = "pedro.gomez@gmail.com", Contrasena = "root", Activo = true },
                new Chef { Id_Chef = 3, Nombre = "Lucía Fernández", Correo = "lucia.fernandez@gmail.com", Contrasena = "root", Activo = true },
                new Chef { Id_Chef = 4, Nombre = "Jorge Ramírez", Correo = "jorge.ramirez@gmail.com", Contrasena = "root", Activo = true },
                new Chef { Id_Chef = 5, Nombre = "Elena Sánchez", Correo = "elena.sanchez@gmail.com", Contrasena = "root", Activo = true });

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id_Cliente = 1, Nombre = "Ana", Apellido = "Martínez" },
                new Cliente { Id_Cliente = 2, Nombre = "Pedro", Apellido = "Gómez" },
                new Cliente { Id_Cliente = 3, Nombre = "María", Apellido = "López" },
                new Cliente { Id_Cliente = 4, Nombre = "Juan", Apellido = "Pérez" },
                new Cliente { Id_Cliente = 5, Nombre = "Laura", Apellido = "Sánchez" },
                new Cliente { Id_Cliente = 6, Nombre = "Carlos", Apellido = "García" },
                new Cliente { Id_Cliente = 7, Nombre = "Sofía", Apellido = "Fernández" },
                new Cliente { Id_Cliente = 8, Nombre = "Diego", Apellido = "Ramírez" },
                new Cliente { Id_Cliente = 9, Nombre = "Valentina", Apellido = "Hernández" },
                new Cliente { Id_Cliente = 10, Nombre = "Luis", Apellido = "Torres" },
                new Cliente { Id_Cliente = 11, Nombre = "Carmen", Apellido = "Díaz" },
                new Cliente { Id_Cliente = 12, Nombre = "Pablo", Apellido = "Moreno" },
                new Cliente { Id_Cliente = 13, Nombre = "Adriana", Apellido = "Ortega" },
                new Cliente { Id_Cliente = 14, Nombre = "Martín", Apellido = "Ruiz" },
                new Cliente { Id_Cliente = 15, Nombre = "Julia", Apellido = "González" },
                new Cliente { Id_Cliente = 16, Nombre = "Elena", Apellido = "Navarro" },
                new Cliente { Id_Cliente = 17, Nombre = "Miguel", Apellido = "Jiménez" },
                new Cliente { Id_Cliente = 18, Nombre = "Sara", Apellido = "Silva" },
                new Cliente { Id_Cliente = 19, Nombre = "Andrés", Apellido = "López" },
                new Cliente { Id_Cliente = 20, Nombre = "Lucía", Apellido = "Martí" });

            modelBuilder.Entity<Categoria>().HasData(
               new Categoria { Id_Categoria = 1, Nombre = "Entradas" },
               new Categoria { Id_Categoria = 2, Nombre = "Platos principales" },
               new Categoria { Id_Categoria = 3, Nombre = "Postres" },
               new Categoria { Id_Categoria = 4, Nombre = "Bebidas frías" },
               new Categoria { Id_Categoria = 5, Nombre = "Bebidas calientes" },
               new Categoria { Id_Categoria = 6, Nombre = "Ensaladas" },
               new Categoria { Id_Categoria = 7, Nombre = "Sopas" },
               new Categoria { Id_Categoria = 8, Nombre = "Aperitivos" },
               new Categoria { Id_Categoria = 9, Nombre = "Sandwiches" },
               new Categoria { Id_Categoria = 10, Nombre = "Mariscos" });

            modelBuilder.Entity<Platillo>().HasData(
               new Platillo { Id_Platillo = 1, Nombre = "Filete de Res", Descripcion = "Filete de res a la parrilla con acompañamiento de vegetales frescos.", Precio = 15000, Id_Categoria = 2 },
               new Platillo { Id_Platillo = 2, Nombre = "Salmón al Horno", Descripcion = "Filete de salmón fresco horneado con hierbas y limón.", Precio = 18000, Id_Categoria = 2 },
               new Platillo { Id_Platillo = 3, Nombre = "Pasta Alfredo", Descripcion = "Pasta fettuccine en salsa cremosa de queso parmesano.", Precio = 12000, Id_Categoria = 2 },
               new Platillo { Id_Platillo = 4, Nombre = "Ensalada César", Descripcion = "Ensalada fresca con pollo a la parrilla y aderezo César.", Precio = 9000, Id_Categoria = 6 },
               new Platillo { Id_Platillo = 5, Nombre = "Pizza Margarita", Descripcion = "Pizza tradicional con salsa de tomate, mozzarella y albahaca fresca.", Precio = 14000, Id_Categoria = 2 },
               new Platillo { Id_Platillo = 6, Nombre = "Ceviche Mixto", Descripcion = "Ceviche peruano con pescado, camarones y calamares en jugo de limón.", Precio = 16000, Id_Categoria = 10 },
               new Platillo { Id_Platillo = 7, Nombre = "Tacos de Carnitas", Descripcion = "Tacos mexicanos con carnitas de cerdo, cebolla y cilantro.", Precio = 11000, Id_Categoria = 8 },
               new Platillo { Id_Platillo = 8, Nombre = "Paella Valenciana", Descripcion = "Paella española con arroz, mariscos, pollo y chorizo.", Precio = 20000, Id_Categoria = 10 },
               new Platillo { Id_Platillo = 9, Nombre = "Sushi Variado", Descripcion = "Variedad de sushi japonés: nigiri, sashimi y rollos especiales.", Precio = 22000, Id_Categoria = 10 },
               new Platillo { Id_Platillo = 10, Nombre = "Lasagna Bolognesa", Descripcion = "Lasagna italiana con carne de res, salsa bolognesa y queso parmesano.", Precio = 13000, Id_Categoria = 2 });

            modelBuilder.Entity<Bebida>().HasData(
                new Bebida { Id_Bebida = 1, Nombre = "Jugo de Naranja", Descripcion = "Jugo natural exprimido de naranjas frescas.", Precio = 4000, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 2, Nombre = "Té Verde Helado", Descripcion = "Té verde helado naturalmente antioxidante y revitalizante.", Precio = 3500, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 3, Nombre = "Smoothie de Frutas", Descripcion = "Bebida refrescante y nutritiva con mezcla de frutas frescas y yogurt.", Precio = 4500, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 4, Nombre = "Agua de Coco", Descripcion = "Agua de coco natural, refrescante y bajo en calorías.", Precio = 3000, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 5, Nombre = "Limonada Natural", Descripcion = "Limonada refrescante preparada con limones frescos.", Precio = 3500, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 6, Nombre = "Mojito sin Alcohol", Descripcion = "Cóctel refrescante sin alcohol con menta, lima, azúcar, soda y hierbabuena.", Precio = 3800, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 7, Nombre = "Café Frappé", Descripcion = "Café frío mezclado con hielo, ideal para días calurosos.", Precio = 4000, Id_Categoria = 5 },
                new Bebida { Id_Bebida = 8, Nombre = "Piña Colada Frozen", Descripcion = "Cóctel frozen con ron, crema de coco y jugo de piña.", Precio = 6500, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 9, Nombre = "Margarita Frozen", Descripcion = "Cóctel frozen de tequila, triple sec, jugo de lima y azúcar.", Precio = 7000, Id_Categoria = 4 },
                new Bebida { Id_Bebida = 10, Nombre = "Daiquiri de Fresa Frozen", Descripcion = "Cóctel frozen con ron blanco, fresas frescas, jugo de limón y azúcar.", Precio = 6800, Id_Categoria = 4 });
            
            modelBuilder.Entity<Mesa>().HasData(
                new Mesa { Id_Mesa = 2, Disponible = true, Id_Cliente = 2, Activa = true },
                new Mesa { Id_Mesa = 3, Disponible = true, Id_Cliente = 3, Activa = true },
                new Mesa { Id_Mesa = 4, Disponible = true, Id_Cliente = 4, Activa = true },
                new Mesa { Id_Mesa = 5, Disponible = true, Id_Cliente = 5, Activa = true },
                new Mesa { Id_Mesa = 6, Disponible = true, Id_Cliente = 6, Activa = true },
                new Mesa { Id_Mesa = 7, Disponible = true, Id_Cliente = 7, Activa = true },
                new Mesa { Id_Mesa = 8, Disponible = true, Id_Cliente = 8, Activa = true },
                new Mesa { Id_Mesa = 9, Disponible = true, Id_Cliente = 9, Activa = true },
                new Mesa { Id_Mesa = 10, Disponible = false, Id_Cliente = 0, Activa = true });

            modelBuilder.Entity<Orden>().HasData(
                new Orden { Id_Orden = 1, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 1, Mesero_Atendio = "Mesero1", Cantidad_Personas = 4, Cancelado = false, Id_Empleado = 1, Id_Cliente = 1, Id_Mesa = 1, Id_Chef = 1, Id_Cuenta = 1 },
                new Orden { Id_Orden = 2, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 2, Mesero_Atendio = "Mesero2", Cantidad_Personas = 2, Cancelado = false, Id_Empleado = 2, Id_Cliente = 2, Id_Mesa = 2, Id_Chef = 2, Id_Cuenta = 2 },
                new Orden { Id_Orden = 3, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 3, Mesero_Atendio = "Mesero3", Cantidad_Personas = 3, Cancelado = false, Id_Empleado = 3, Id_Cliente = 3, Id_Mesa = 3, Id_Chef = 3, Id_Cuenta = 3 },
                new Orden { Id_Orden = 4, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 4, Mesero_Atendio = "Mesero4", Cantidad_Personas = 5, Cancelado = false, Id_Empleado = 4, Id_Cliente = 4, Id_Mesa = 4, Id_Chef = 4, Id_Cuenta = 4 },
                new Orden { Id_Orden = 5, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 5, Mesero_Atendio = "Mesero5", Cantidad_Personas = 6, Cancelado = false, Id_Empleado = 5, Id_Cliente = 5, Id_Mesa = 5, Id_Chef = 5, Id_Cuenta = 5 },
                new Orden { Id_Orden = 6, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 6, Mesero_Atendio = "Mesero6", Cantidad_Personas = 2, Cancelado = false, Id_Empleado = 1, Id_Cliente = 6, Id_Mesa = 6, Id_Chef = 2, Id_Cuenta = 6 },
                new Orden { Id_Orden = 7, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 7, Mesero_Atendio = "Mesero7", Cantidad_Personas = 4, Cancelado = false, Id_Empleado = 2, Id_Cliente = 7, Id_Mesa = 7, Id_Chef = 3, Id_Cuenta = 7 },
                new Orden { Id_Orden = 8, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 8, Mesero_Atendio = "Mesero8", Cantidad_Personas = 3, Cancelado = false, Id_Empleado = 3, Id_Cliente = 8, Id_Mesa = 8, Id_Chef = 4, Id_Cuenta = 8 },
                new Orden { Id_Orden = 9, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 9, Mesero_Atendio = "Mesero9", Cantidad_Personas = 2, Cancelado = false, Id_Empleado = 4, Id_Cliente = 9, Id_Mesa = 9, Id_Chef = 1, Id_Cuenta = 9 },
                new Orden { Id_Orden = 10, Fecha = DateTime.Now, Hora = DateTime.Now.TimeOfDay, Numero_Orden = 10, Mesero_Atendio = "Mesero10", Cantidad_Personas = 4, Cancelado = false, Id_Empleado = 5, Id_Cliente = 10, Id_Mesa = 10, Id_Chef = 5, Id_Cuenta = 10 });

            modelBuilder.Entity<DetalleOrden>().HasData(
                new DetalleOrden { Id_Detalle_Orden = 1, Id_Orden = 1, Id_Platillo = 1, Cantidad_Platillo = 2, Id_Bebida = 1, Cantidad_Bebida = 1, Precio = 100.00m },
                new DetalleOrden { Id_Detalle_Orden = 2, Id_Orden = 2, Id_Platillo = 3, Cantidad_Platillo = 1, Id_Bebida = 2, Cantidad_Bebida = 2, Precio = 150.00m },
                new DetalleOrden { Id_Detalle_Orden = 3, Id_Orden = 3, Id_Platillo = 2, Cantidad_Platillo = 3, Id_Bebida = 3, Cantidad_Bebida = 3, Precio = 200.00m },
                new DetalleOrden { Id_Detalle_Orden = 4, Id_Orden = 4, Id_Platillo = 4, Cantidad_Platillo = 1, Id_Bebida = 4, Cantidad_Bebida = 2, Precio = 175.00m },
                new DetalleOrden { Id_Detalle_Orden = 5, Id_Orden = 5, Id_Platillo = 5, Cantidad_Platillo = 2, Id_Bebida = 5, Cantidad_Bebida = 1, Precio = 125.00m });

            modelBuilder.Entity<Cuenta>().HasData(
                new Cuenta { Id_Cuenta = 1, Id_Cliente = 1, Id_Orden = 1, Total = 1500, Cancelado = false },
                new Cuenta { Id_Cuenta = 2, Id_Cliente = 2, Id_Orden = 2, Total = 1200, Cancelado = true },
                new Cuenta { Id_Cuenta = 3, Id_Cliente = 3, Id_Orden = 3, Total = 1800, Cancelado = false },
                new Cuenta { Id_Cuenta = 4, Id_Cliente = 4, Id_Orden = 4, Total = 900, Cancelado = false },
                new Cuenta { Id_Cuenta = 5, Id_Cliente = 5, Id_Orden = 5, Total = 2000, Cancelado = true },
                new Cuenta { Id_Cuenta = 6, Id_Cliente = 6, Id_Orden = 6, Total = 1600, Cancelado = false },
                new Cuenta { Id_Cuenta = 7, Id_Cliente = 7, Id_Orden = 7, Total = 2100, Cancelado = false },
                new Cuenta { Id_Cuenta = 8, Id_Cliente = 8, Id_Orden = 8, Total = 1400, Cancelado = true },
                new Cuenta { Id_Cuenta = 9, Id_Cliente = 9, Id_Orden = 9, Total = 1750, Cancelado = false },
                new Cuenta { Id_Cuenta = 10, Id_Cliente = 10, Id_Orden = 10, Total = 1950, Cancelado = false });
        }
    }
}
