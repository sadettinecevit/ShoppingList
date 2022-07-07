using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Domain.Entities
{
    public class Group : IBaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime CreateTime { get; set; } = DateTime.Now;	
		public DateTime? CompeleteTime { get; set; }
        [Required]
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
    }
}
