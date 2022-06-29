using MediatR;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateGroupDto : IRequest<int>
	{
		public string Name { get; set; }
		public DateTime? CompeleteTime { get; set; }
		public IQueryable<Product> ProductList { get; set; }
	}

}
