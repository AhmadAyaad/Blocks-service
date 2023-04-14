using Tahalouf.App.Helpers;
using Tahalouf.App.IService;
using Tahalouf.App.Models;
using static Tahalouf.App.Constants.Path;
namespace Tahalouf.App.Services
{
    public class SearchService : ISearchService
    {
        public IEnumerable<SearchResultDTO> SearchByKeyWord(string keyword)
        {
            //TODO: Add keyword with it results to cache
            string[] filePaths = Directory.GetFiles(PagesDirectoryPath, Constants.Constant.JsonExtension,
                                              SearchOption.TopDirectoryOnly);
            var data = new List<SearchResultDTO>();
            keyword = keyword.ToLower();
            Parallel.ForEach(filePaths, filePath =>
            {
                var result = JsonHelpers.ReadFile<SearchResultDTO>(filePath);
                data.Add(new SearchResultDTO { Title = result.Title, Code = result.Code });
            });
            return data.Where(d => d.Title.ToLowerInvariant().Contains(keyword))
                             .Select(res => new SearchResultDTO
                             {
                                 Code = res.Code,
                                 Title = res.Title,
                             });
        }
    }
}
