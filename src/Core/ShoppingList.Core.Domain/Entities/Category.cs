using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Domain.Entities
{
    public class Category : IBaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime CreateTime { get; set; } = DateTime.Now;
		public DateTime? CompeleteTime { get; set; }
        [Required]
		[ForeignKey("CartId")]
		public virtual Cart Cart { get; set; }
    }
}
