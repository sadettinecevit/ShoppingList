using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Domain.Entities
{
    public class Cart : IBaseEntity
	{
		[Key, Required]
		public string Id { get; set; }
		[Required]
		public User Owner { get; set; }
		[Required]
		public DateTime CreateTime { get; set; } = DateTime.Now;
		[Required]
		public IQueryable<Category> ShoppingCategory { get; set; }
    }
}
