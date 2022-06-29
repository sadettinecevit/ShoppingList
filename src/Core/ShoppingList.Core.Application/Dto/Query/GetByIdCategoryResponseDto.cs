using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdCategoryResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? CompeleteTime { get; set; }
        public IQueryable<Group> ShoppingGroup { get; set; }
    }

}
