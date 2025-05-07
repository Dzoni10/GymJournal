namespace GymJournal.Infrastructure
{
    public class PagedResult<T>
    {
        public List<T> Results { get; }
        public int TotalCount { get; }


        public PagedResult(List<T> items, int totalCount)
            {
            Results = items;
            TotalCount = totalCount;
            }
    }
}
