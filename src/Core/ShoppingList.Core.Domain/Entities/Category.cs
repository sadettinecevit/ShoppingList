using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Domain.Entities
{
    public class Category : IBaseEntity
	{
		[Key, Required]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime CreateTime { get; set; } = DateTime.Now;
		public DateTime? CompeleteTime { get; set; }
		[Required]
		public IQueryable<Group> ShoppingGroup { get; set; }
    }
}
