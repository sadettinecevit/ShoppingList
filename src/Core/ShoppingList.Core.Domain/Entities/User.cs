
using Microsoft.AspNetCore.Identity;
using ShoppingList.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Domain.Entities
{
    public class User : IdentityUser, IBaseEntity
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string LastName { get; set; }
	}
}
