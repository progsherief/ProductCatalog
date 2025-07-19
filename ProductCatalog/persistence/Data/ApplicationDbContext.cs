namespace ProductCatalog.Infrastructure.Persistence;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ProductHistory> ProductHistories => Set<ProductHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Product & ProductHistory
        modelBuilder.Entity<Product>()
      .HasMany(p => p.History)
      .WithOne(h => h.Product)
      .HasForeignKey(h => h.ProductId);


        modelBuilder.Entity<ProductHistory>()
    .HasOne<ApplicationUser>()
    .WithMany()
    .HasForeignKey(h => h.UpdatedByUserId)
    .OnDelete(DeleteBehavior.Restrict);

        // Seeding Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),Name = "Electronics" },
            new Category { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),Name = "Clothing" },
            new Category { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),Name = "Home" }
        );
    }
}
