namespace MovieDBWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base("name=MovieDBContext")
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Studio>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Studio>()
                .Property(e => e.HQCity)
                .IsFixedLength();
        }
    }
}
