using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WWF_Api
{
    public partial class WWFContext : DbContext
    {
        public WWFContext()
        {
        }

        public WWFContext(DbContextOptions<WWFContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Animalonconttinents> Animalonconttinents { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsDetails> NewsDetails { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WWF;Username=postgres;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("animal");

                entity.Property(e => e.AnimalId).HasColumnName("animal_id");

                entity.Property(e => e.AnimalName)
                    .IsRequired()
                    .HasColumnName("animal_name")
                    .HasMaxLength(100);

                entity.Property(e => e.CatId)
                    .HasColumnName("cat_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Habitat)
                    .IsRequired()
                    .HasColumnName("habitat")
                    .HasMaxLength(500);

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasColumnName("place")
                    .HasMaxLength(200);

                entity.Property(e => e.Population).HasColumnName("population");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_category");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_status");
            });

            modelBuilder.Entity<Animalonconttinents>(entity =>
            {
                entity.HasKey(e => e.AocId)
                    .HasName("pk_aoc");

                entity.ToTable("animalonconttinents");

                entity.Property(e => e.AocId).HasColumnName("aoc_id");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("animal_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConId)
                    .HasColumnName("con_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Animalonconttinents)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("fk_animal");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Animalonconttinents)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("fk_con");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("pk_category");

                entity.ToTable("category");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.CatName)
                    .HasColumnName("cat_name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("pk_continent");

                entity.ToTable("continent");

                entity.Property(e => e.ConId).HasColumnName("con_id");

                entity.Property(e => e.ConName)
                    .IsRequired()
                    .HasColumnName("con_name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.NewsId).HasColumnName("news_id");

                entity.Property(e => e.Head)
                    .IsRequired()
                    .HasColumnName("head");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnName("img");

                entity.Property(e => e.PublishedD)
                    .IsRequired()
                    .HasColumnName("published_d");

                entity.Property(e => e.PublishedT)
                    .IsRequired()
                    .HasColumnName("published_t");
            });

            modelBuilder.Entity<NewsDetails>(entity =>
            {
                entity.HasKey(e => e.DnewsId)
                    .HasName("dnews_pk");

                entity.ToTable("news_details");

                entity.Property(e => e.DnewsId).HasColumnName("dnews_id");

                entity.Property(e => e.DIng).HasColumnName("d_ing");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Head).HasColumnName("head");

                entity.Property(e => e.NewsId).HasColumnName("news_id");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewsDetails)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("dnews_fk");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name")
                    .HasMaxLength(30);
            });
        }
    }
}
