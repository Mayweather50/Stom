using ProjectStomatology.Services;

namespace ProjectStomatology.Models
{
    public class SearchResultsModel
    {
        public string SearchText { get; set; }

        public List<Order> Results { get; set; }
    }
}
