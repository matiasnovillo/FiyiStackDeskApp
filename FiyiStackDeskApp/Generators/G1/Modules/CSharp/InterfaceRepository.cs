namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string InterfaceRepository(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;
using System.Data;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces
{{
    public partial interface I{Table.Name}Repository
    {{
        #region Async Queries
        Task<int> CountAsync();

        Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id);

        Task<List<{Table.Name}>> GetAllAsync();

        Task<List<{Table.Name}>> GetAllBy{Table.Name}IdCheckedAsync(List<long> listChecked{Table.Name}Ids);

        Task<List<{Table.Name}>> GetAllBy{Table.Name}IdForModalAsync(string textToSearch);

        Task<Paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginatedAsync(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Async Non-Queries
        Task<int> AddAsync({Table.Name} {Table.Name.ToLower()});

        Task<int> AddRangeAsync(List<{Table.Name}> list{Table.Name});

        Task<int> UpdateAsync({Table.Name} {Table.Name.ToLower()});

        Task<int> DeleteOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id);

        Task<int> DeleteAllAsync();

        Task<int> DeleteManyAsync(List<{Table.Name}> list{Table.Name});
        #endregion

        #region Methods for DataTable
        Task<DataTable> GetAllBy{Table.Name}IdInDataTableAsync(List<long> listChecked{Table.Name}Ids);

        Task<DataTable> GetAllInDataTableAsync();
        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
