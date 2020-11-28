namespace Slova.Dictionary.Repos.Filters
{
    public class ListWordsFilter
    {
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        
        // TODO Add orderby expression with dynamic query based on Expression<>
    }
}