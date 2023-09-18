using Nest;

namespace ProjectStomatology.Services
{
    public interface ISearchClient
    {
        ISearchResponse<Order> SearchOrder(string searchText);
    }
}
