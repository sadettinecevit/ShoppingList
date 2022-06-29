using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdCartResponseDto
	{
        public string Id { get; set; }
        public User Owner { get; set; }
		public DateTime CreateTime { get; set; }
		public IQueryable<Category> ShoppingCategory { get; set; }
	}

}
