using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Domain.Entities
{
    public class Product : IBaseEntity
	{
		[Key, Required]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Brand { get; set; }
		[Required]
		public float Quantity { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public bool IsTaken { get; set; } = false;
    }
}
