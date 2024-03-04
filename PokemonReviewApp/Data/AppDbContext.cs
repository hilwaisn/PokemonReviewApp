using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PokemonCategory>()
				.HasKey(pc => new { pc.PokemonId, pc.CategoryId });
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(p => p.Pokemons)
				.WithMany(pc => pc.PokemonCategories)
				.HasForeignKey(p => p.PokemonId);
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(p => p.Categorys)
				.WithMany(pc => pc.PokemonCategories)
				.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<PokemonOwner>()
				.HasKey(po => new { po.PokemonId, po.OwnerId});
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(p => p.Pokemons)
				.WithMany(po => po.PokemonOwners)
				.HasForeignKey(p => p.PokemonId);
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(p => p.Owners)
				.WithMany(po => po.PokemonOwners)
				.HasForeignKey(p => p.OwnerId);

			//base.OnModelCreating(modelBuilder);
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<Pokemon> Pokemons { get; set; }	
		public DbSet<PokemonCategory> PokemonCategories { get; set; }
		public DbSet<PokemonOwner> PokemonOwners { get; set;}
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Reviewer> Reviewers { get; set; }
	}
}
