using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Domain.Entities
{
    public class Cart : IBaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		[Required]
		[ForeignKey("OwnerId")]
		public virtual User Owner { get; set; }
		public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
