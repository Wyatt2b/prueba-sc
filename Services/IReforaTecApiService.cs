using ReforaTec.Models;  // <-- Importante
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReforaTec.Services
{
    public interface IReforaTecApiService
    {
        Task<List<ApiTree>> GetTreesAsync();
        Task<ApiTree> GetTreeByIdAsync(int id);
        Task<ApiTree> CreateTreeAsync(ApiTree newTree);

        Task<List<ApiSpecies>> GetSpeciesAsync();
        Task<ApiSpecies> GetSpeciesByIdAsync(int id);
        Task<ApiSpecies> CreateSpeciesAsync(ApiSpecies newSpecies);

        Task<List<ApiValue>> GetValuesAsync();
        Task<ApiValue> GetValueByIdAsync(int id);
        Task<ApiValue> CreateValueAsync(ApiValue newValue);
    }
}