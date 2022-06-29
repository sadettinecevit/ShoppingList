namespace ShoppingList.Application.Dto.Query
{
    public abstract class FilteredPageQuery
	{
        public int DataCount { get; set; } = 1;
        public int PageIndex { get; set; } = 1;
        public string Keyword { get; set; } = string.Empty;
    }

}
