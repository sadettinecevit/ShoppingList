using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Domain.Entities
{
    public class Group : IBaseEntity
	{
		[Key, Required]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime CreateTime { get; set; } = DateTime.Now;	
		public DateTime? CompeleteTime { get; set; }
		[Required]
		public IQueryable<Product> ProductList { get; set; }
    }
}
