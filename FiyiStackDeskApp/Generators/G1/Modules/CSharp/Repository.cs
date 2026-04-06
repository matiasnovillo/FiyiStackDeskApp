namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string Repository(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.CMS.UserBack.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces;
using {GeneratorConfigurationComponent.ChosenProject.Name}.DatabaseContexts;
using System.Text.RegularExpressions;
using System.Data;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Repositories
{{
    public partial class {Table.Name}Repository(
        IDbContextFactory<{GeneratorConfigurationComponent.ChosenProject.Name}DbContext> _factory) : I{Table.Name}Repository
    {{
        #region Async Queries    
        public async Task<int> CountAsync()
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();                
            
            int RowsNumber = await DbContext.{Table.Name}
                .AsNoTracking()
                .CountAsync();

            return RowsNumber;
        }}

        public async Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id)
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();
                
            {Table.Name}? {Table.Name} = await DbContext.{Table.Name}
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);

            return {Table.Name};
        }}

        public async Task<List<{Table.Name}>> GetAllAsync()
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            List<{Table.Name}> List{Table.Name} = await DbContext.{Table.Name}
                .AsNoTracking()
                .ToListAsync();

            return List{Table.Name};
        }}

        public async Task<List<{Table.Name}>> GetAllBy{Table.Name}IdCheckedAsync(List<long> listChecked{Table.Name}Ids)
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            List<{Table.Name}> List{Table.Name} = await DbContext.{Table.Name}
                .AsNoTracking()
                .Where(x => listChecked{Table.Name}Ids.Contains(x.{Table.Name}Id))
                .ToListAsync();

            return List{Table.Name};
        }}

        public async Task<List<{Table.Name}>> GetAllBy{Table.Name}IdForModalAsync(string textToSearch)
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            List<{Table.Name}> List{Table.Name} = await DbContext.{Table.Name}
                .AsNoTracking()
                .Where(x => x.{Table.Name}Id.ToString().Contains(textToSearch))
                .ToListAsync();

            return List{Table.Name};
        }}

        public async Task<Paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginatedAsync(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize)
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

                string[] Words = Regex
                    .Replace(textToSearch
                    .Trim(), @""\s+"", "" "")
                    .Split("" "", StringSplitOptions.RemoveEmptyEntries);

                List<{Table.Name}> List{Table.Name} = await DbContext.{Table.Name}
                    .AsNoTracking()
                    .Where(x => strictSearch ?
                        Words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                        Words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                    .OrderByDescending(x => x.DateTimeLastModification)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                long TotalRecordsInDatabase = await DbContext.{Table.Name}.LongCountAsync();

                int TotalRecordsInTheList = List{Table.Name}.Count;

                List<long> PossibleUserCreationIds = List{Table.Name}
                    .Select(x => x.UserCreationId)
                    .Distinct()
                    .ToList();

                List<User> ListUserCreation = await DbContext.User
                    .Where(x => PossibleUserCreationIds.Contains(x.UserId))
                    .ToListAsync();

                List<long> PossibleUserLastModificationIds = List{Table.Name}
                    .Select(x => x.UserCreationId)
                    .Distinct()
                    .ToList();

                List<User> ListUserLastModification = await DbContext.User
                    .Where(x => PossibleUserLastModificationIds.Contains(x.UserId))
                    .ToListAsync();

                return new Paginated{Table.Name}DTO
                {{
                    List{Table.Name} = List{Table.Name},
                    ListUserCreation = ListUserCreation,
                    ListUserLastModification = ListUserLastModification,
                    TotalRecordsInDatabase = TotalRecordsInDatabase,
                    TotalRecordsInTheList = TotalRecordsInTheList,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                }};
        }}
        #endregion

        #region Async Non-Queries
        public async Task<int> AddAsync({Table.Name} {Table.Name.ToLower()})
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            EntityEntry<{Table.Name}> {Table.Name}ToAdd = await DbContext.{Table.Name}.AddAsync({Table.Name.ToLower()});

            int AffectedRowsNumber = await DbContext.SaveChangesAsync();

            return AffectedRowsNumber;
        }}

        public async Task<int> AddRangeAsync(List<{Table.Name}> list{Table.Name})
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            await DbContext.{Table.Name}.AddRangeAsync(list{Table.Name});

            int AffectedRowsNumber = await DbContext.SaveChangesAsync();

            return AffectedRowsNumber;
        }}

        public async Task<int> UpdateAsync({Table.Name} {Table.Name.ToLower()})
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            DbContext.{Table.Name}.Update({Table.Name.ToLower()});

            int AffectedRowsNumber = await DbContext.SaveChangesAsync();

            return AffectedRowsNumber;
        }}

        public async Task<int> DeleteOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id)
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            int AffectedRowsNumber = await DbContext.{Table.Name}
                .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                .ExecuteDeleteAsync();

            return AffectedRowsNumber;
        }}

        public async Task<int> DeleteAllAsync()
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            int AffectedRowsNumber = await DbContext.{Table.Name}
                .ExecuteDeleteAsync();

            return AffectedRowsNumber;
        }}

        public async Task<int> DeleteManyAsync(List<{Table.Name}> list{Table.Name})
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            DbContext.{Table.Name}.RemoveRange(list{Table.Name});

            int AffectedRows = await DbContext.SaveChangesAsync();

            return AffectedRows;
        }}
        #endregion

        #region Methods for DataTable
        public async Task<DataTable> GetAllBy{Table.Name}IdInDataTableAsync(List<long> listChecked{Table.Name}Ids)
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            DataTable DataTable = new();

            DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
            {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

            var ListChecked{Table.Name} = await DbContext.{Table.Name}
                .AsNoTracking()
                .Where(x => listChecked{Table.Name}Ids.Contains(x.{Table.Name}Id))
                .ToListAsync();

            foreach ({Table.Name} {Table.Name} in ListChecked{Table.Name})
            {{
                if ({Table.Name} != null)
                {{
                    DataTable.Rows.Add(
                    {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable}
                    );
                }}
            }}                

            return DataTable;
        }}

        public async Task<DataTable> GetAllInDataTableAsync()
        {{
            await using var DbContext = await _factory.CreateDbContextAsync();

            List<{Table.Name}> List{Table.Name} = await DbContext.{Table.Name}
                .AsNoTracking()
                .ToListAsync();

            DataTable DataTable = new();
            DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
            {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

            foreach ({Table.Name} {Table.Name} in List{Table.Name})
            {{
                DataTable.Rows.Add(
                    {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable}
                    );
            }}

            return DataTable;
        }}
        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
