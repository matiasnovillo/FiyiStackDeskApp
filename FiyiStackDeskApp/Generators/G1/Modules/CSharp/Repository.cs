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
    public class {Table.Name}Repository(
        IDbContextFactory<{GeneratorConfigurationComponent.ChosenProject.Name}DbContext> _factory) : I{Table.Name}Repository
    {{
        #region Async Queries    
        public async Task<IQueryable<{Table.Name}>> AsQueryableAsync()
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                return DbContext.{Table.Name}.AsQueryable();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<int> CountAsync()
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();                

                return await DbContext.{Table.Name}.CountAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id)
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();
                
                return await DbContext.{Table.Name}
                                .FirstOrDefaultAsync(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<List<{Table.Name}>> GetAllAsync()
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                return await DbContext.{Table.Name}.ToListAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<List<{Table.Name}>> GetAllBy{Table.Name}IdCheckedAsync(List<long> lstLONG{Table.Name}IdChecked)
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                return await DbContext.{Table.Name}
                                       .Where(x => lstLONG{Table.Name}IdChecked.Contains(x.{Table.Name}Id))
                                       .ToListAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<List<{Table.Name}>> GetAllBy{Table.Name}IdForModalAsync(string textToSearch)
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                return await DbContext.{Table.Name}
                                       .Where(x => x.{Table.Name}Id.ToString().Contains(textToSearch))
                                       .ToListAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginatedAsync(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize)
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                string[] words = Regex
                    .Replace(textToSearch
                    .Trim(), @""\s+"", "" "")
                    .Split("" "");

                List<{Table.Name}> lst{Table.Name} = await DbContext.{Table.Name}
                    .AsQueryable()
                    .Where(x => strictSearch ?
                        words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                        words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                    .OrderByDescending(x => x.DateTimeLastModification)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                int Total{Table.Name} = lst{Table.Name}.Count;

                List<long> lstLONGUserCreationId = lst{Table.Name}
                    .Select(x => x.UserCreationId)
                    .ToList();

                List<long> lstLONGUserLastModificationId = lst{Table.Name}
                    .Select(x => x.UserLastModificationId)
                    .ToList();

                List<User> lstUserCreation = await DbContext.User
                    .Where(x => lstLONGUserCreationId.Contains(x.UserCreationId))
                    .ToListAsync();

                List<User> lstUserLastModification = await DbContext.User
                    .Where(x => lstLONGUserLastModificationId.Contains(x.UserLastModificationId))
                    .ToListAsync();

                return new paginated{Table.Name}DTO
                {{
                    lst{Table.Name} = lst{Table.Name},
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalRegisters = Total{Table.Name},
                    PageIndex = pageIndex,
                    PageSize = pageSize
                }};
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Async Non-Queries
        public async Task<bool> AddAsync({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                EntityEntry<{Table.Name}> {Table.Name}ToAdd = await DbContext.{Table.Name}.AddAsync({Table.Name.ToLower()});

                bool result = await DbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> AddRangeAsync(List<{Table.Name}> lst{Table.Name})
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                await DbContext.{Table.Name}.AddRangeAsync(lst{Table.Name});

                bool result = await DbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> UpdateAsync({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                DbContext.{Table.Name}.Update({Table.Name.ToLower()});

                bool result = await DbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> DeleteOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id)
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                await DbContext.{Table.Name}
                    .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                    .ExecuteDeleteAsync();

                bool Result = await DbContext.SaveChangesAsync() > 0;

                return Result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> DeleteAll{Table.Name}Async()
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                await DbContext.{Table.Name}
                    .ExecuteDeleteAsync();

                return true;
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<bool> DeleteManyBy{Table.Name}IdAsync(List<{Table.Name}> lst{Table.Name})
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                DbContext.{Table.Name}.RemoveRange(lst{Table.Name});

                int AffectedRows = await DbContext.SaveChangesAsync();

                bool Result = AffectedRows > 0;

                return Result;
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Methods for DataTable
        public async Task<DataTable> GetAllBy{Table.Name}IdInDataTableAsync(List<long> lst{Table.Name}Checked)
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

                foreach (long {Table.Name}Id in lst{Table.Name}Checked)
                {{
                    {Table.Name} {Table.Name.ToLower()} = await DbContext.{Table.Name}
                        .Where(x => x.{Table.Name}Id == {Table.Name}Id).FirstOrDefaultAsync();

                    if ({Table.Name.ToLower()} != null)
                    {{
                        DataTable.Rows.Add(
                        {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable}
                        );
                    }}
                }}                

                return DataTable;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<DataTable> GetAllInDataTableAsync()
        {{
            try
            {{
                await using var DbContext = await _factory.CreateDbContextAsync();

                List<{Table.Name}> lst{Table.Name} = await DbContext.{Table.Name}
                    .ToListAsync();

                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

                foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
                {{
                    DataTable.Rows.Add(
                        {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable}
                        );
                }}

                return DataTable;
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion
    }}
}}
";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
