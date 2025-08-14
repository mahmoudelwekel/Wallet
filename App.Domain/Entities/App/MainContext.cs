using Microsoft.EntityFrameworkCore;

#nullable disable

namespace App.Domain.Entities.App
{
    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Example> Examples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\.;Database=aspnet-App-DA764CC4-4005-4F03-9991-BE8ED358A558;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Example>(entity =>
            {
                entity.Property(e => e.ExampleId).HasColumnName("Example_ID");

                entity.Property(e => e.ExampleAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Example_Amount");

                entity.Property(e => e.ExampleCreateBy)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("Example_Create_By");

                entity.Property(e => e.ExampleCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Example_Create_Date");

                entity.Property(e => e.ExampleFromUserId)
                    .HasMaxLength(450)
                    .HasColumnName("Example_From_User_ID");

                entity.Property(e => e.ExampleToUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("Example_To_User_ID");

                entity.Property(e => e.ExampleUpdateBy)
                    .HasMaxLength(450)
                    .HasColumnName("Example_Update_By");

                entity.Property(e => e.ExampleUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Example_Update_Date");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
