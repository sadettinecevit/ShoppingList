using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Domain.Entities
{
    public class Product : IBaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Required]
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }
}
