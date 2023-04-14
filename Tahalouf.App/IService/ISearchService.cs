using Tahalouf.App.Models;

namespace Tahalouf.App.IService
{
    public interface ISearchService
    {
        IEnumerable<SearchResultDTO> SearchByKeyWord(string keyword);
    }
}
