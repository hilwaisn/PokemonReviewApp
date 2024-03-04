namespace PokemonReviewApp.Models
{
	public class PokemonOwner
	{
		public int PokemonId { get; set; }
		public int OwnerId { get; set; }
		public Pokemon Pokemons { get; set; }
		public Owner Owners { get; set; }
	}
}
