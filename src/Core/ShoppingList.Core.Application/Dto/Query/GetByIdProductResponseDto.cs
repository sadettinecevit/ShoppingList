namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdProductResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsTaken { get; set; }
    }

}
