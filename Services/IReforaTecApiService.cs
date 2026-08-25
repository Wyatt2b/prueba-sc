using ReforaTec.Models; // Asegúrate de que el namespace sea el correcto

namespace ReforaTec.Services
{
    public interface IReforaTecApiService
    {
        // --- Trees ---
        Task<List<Tree>> GetTreesAsync();
        Task<Tree> GetTreeByIdAsync(int id);
        Task<Tree> CreateTreeAsync(Tree newTree);

        // --- Species ---
        Task<List<Species>> GetSpeciesAsync();
        Task<Species> GetSpeciesByIdAsync(int id);
        Task<Species> CreateSpeciesAsync(Species newSpecies);

        // --- Values ---
        Task<List<Value>> GetValuesAsync();
        Task<Value> GetValueByIdAsync(int id);
        Task<Value> CreateValueAsync(Value newValue);
    }
}