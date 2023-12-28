using Clothings_Store.Models.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Clothings_Store.Data
{
    public class StoreContext : IdentityDbContext<AppUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Promotion> Promotions { get; set; }

        public virtual DbSet<Size> Sizes { get; set; }

        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code).HasMaxLength(10);
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Colors");

                entity.Property(e => e.Ghichu).HasMaxLength(50);
                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Order");

                entity.ToTable("Order");

                entity.Property(e => e.Address).HasMaxLength(250);
                entity.Property(e => e.DeliTime).HasColumnType("date");
                entity.Property(e => e.Note).HasMaxLength(200);
                entity.Property(e => e.OrdTime).HasColumnType("date");
                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Order__PaymentId");

                entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Order__Status");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.StockId }).HasName("PK__OrderDetail");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDetail__OrderId");

                entity.HasOne(d => d.Stock).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDetail__StockId");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.Status).HasName("PK__OrderStatus");

                entity.ToTable("OrderStatus");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Payment");

                entity.ToTable("Payment");

                entity.Property(e => e.Ghichu).HasMaxLength(200);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CostPrice).HasColumnName("costPrice");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.StockInDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("date")
                    .HasColumnName("stockInDate");
                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__CategoryId");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.PromotionId).HasName("PK__Promotion");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.DiscountPercentage)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("discount_percentage");
                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");
                entity.Property(e => e.PromotionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("promotion_name");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Sizes");

                entity.Property(e => e.Ghichu).HasMaxLength(50);
                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Stock");

                entity.ToTable("Stock");

                entity.Property(e => e.Stock1).HasColumnName("Stock");
                entity.Property(e => e.StockInDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("date")
                    .HasColumnName("stockInDate");

                entity.HasOne(d => d.Color).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__Stock__ColorId");

                entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Stock__ProductId");

                entity.HasOne(d => d.Size).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__Stock__SizeId");
            });

            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

        }

    }
}
