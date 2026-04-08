using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiyiStackDeskApp.Generators.G1
{
    public class G1FieldChainer
    {
        public int NumberOfFields { get; set; } = 0;

        public string PropertiesForEntity { get; set; } = "";

        public string PropertiesForEntityConfiguration { get; set; } = "";

        public string PropertiesInHTML_TD_ForExportationService { get; set; } = "";
        public string PropertiesInHTML_TH_ForExportationService { get; set; } = "";

        public string PropertiesInHTML_TH_ForBlazorPageQuery { get; set; } = "";

        public string PropertiesInHTML_TD_ForBlazorPageQuery { get; set; } = "";

        public string PropertiesInHTML_Card_ForBlazorPageQuery { get; set; } = "";

        public string Properties_ForExcel_Converter_DefineDataColumns { get; set; } = "";

        public string PropertiesForRepository_DataTable { get; set; } = "";

        public string PropertiesForRepository_DataTable1 { get; set; } = "";

        public string Properties_ForIronPDF_Converter { get; set; } = "";

        public string PropertiesInHTML_BlazorNonQueryPage { get; set; } = "";

        public string UploadFileMethod_BlazorNonQueryPage { get; set; } = "";

        public string Properties_ForImport1 { get; set; } = "";
        public string Properties_ForImport2 { get; set; } = "";

        public int iForImportInService { get; set; } = 7; //Start in 7 because it adds the auditory fields that are 5 + Id

        public string ErrorMessage_InNonQueryBlazor { get; set; } = "";

        public string Handlers_InNonQueryBlazor { get; set; } = "";

        public string Searchers_BlazorNonQueryPage { get; set; } = "";
        public string Injections_BlazorNonQueryPage { get; set; } = "";
        public string ForeignListsDeclaration_BlazorNonQueryPage { get; set; } = "";
        public string ForeignListsGet_BlazorNonQueryPage { get; set; } = "";
        public string EditPartFK_BlazorNonQueryPage { get; set; } = "";
        public string ForeignLists_DTO { get; set; } = "";
        public string ForeignUsings_DTO { get; set; } = "";
        public string CancelationTokensProperties_BlazorNonQueryPage { get; set; } = "";

        public string ModalsInBlazorPageNonQuery { get; set; } = "";

        public G1FieldChainer() 
        { 
        }

        public G1FieldChainer(ServiceProvider serviceProvider, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table, Areas.FiyiStackDeskApp.ProjectBack.Entities.Project Project)
        {
            IFieldRepository FieldRepository = serviceProvider.GetRequiredService<IFieldRepository>();

            Areas.FiyiStackDeskApp.FieldBack.Entities.Field Field = new();
            List<Areas.FiyiStackDeskApp.FieldBack.Entities.Field> lstField = FieldRepository.GetAllByTableIdByName(Table.TableId, "");
            NumberOfFields = lstField.Count;

            foreach (Areas.FiyiStackDeskApp.FieldBack.Entities.Field field in lstField)
            {
                ErrorMessage_InNonQueryBlazor += $@"private string ErrorMessage{field.Name} {{ get; set; }} = """";
    ";

                PropertiesForEntity += field.HistoryUser == "" ? "" : $@"        ///<summary>
        /// {field.HistoryUser}
        ///</summary>
";

                PropertiesInHTML_TD_ForExportationService += $@"
    <td align=""""left"""" valign=""""top"""">
        <div style=""""height: 12px; line-height: 12px; font-size: 10px;"""">&nbsp;</div>
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"""">{{{Table.Name}.{field.Name}}}</span>
        </font>
        <div style=""""height: 40px; line-height: 40px; font-size: 38px;"""">&nbsp;</div>
    </td>";

                PropertiesInHTML_TH_ForExportationService += $@"
    <th align=""""left"""" valign=""""top"""" style=""""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"""">
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px; font-weight: 600;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"""">{field.Name}</span>
        </font>
        <div style=""""height: 10px; line-height: 10px; font-size: 8px;"""">&nbsp;</div>
    </th>
    ";

                Properties_ForExcel_Converter_DefineDataColumns += $@"DataColumn DataTableColumn{field.Name}ForDataTable{Table.Name}Copy = new()
            {{
                DataType = typeof(string),
                ColumnName = ""{field.Name}""
            }};
            DataTable{Table.Name}Copy.Columns.Add(DataTableColumn{field.Name}ForDataTable{Table.Name}Copy);

            ";

                PropertiesForRepository_DataTable += $"{Table.Name}.{field.Name},\r\t\t\t\t\t";

                Properties_ForIronPDF_Converter += $@"<th align=""""left"""" valign=""""top"""" style=""""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"""">
            <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px; font-weight: 600;"""">
                <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"""">{field.Name}&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""""height: 10px; line-height: 10px; font-size: 8px;"""">&nbsp;</div>
        </th>";

                if (field.Name != Table.Name + "Id")
                {
                    PropertiesForRepository_DataTable1 += $@"DataTable.Columns.Add(""{field.Name}"", typeof(string));
            ";
                }
                
                switch (Convert.ToInt32(field.DataTypeId))
                {
                    case 0:
                        throw new Exception("You must choose a Data Type");
                    //LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG
                    //LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG//LONG
                    case 3: //Long

                        

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""bigint"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                            PropertiesForEntity +=
$@"        [Long(required: {(field.Nullable == true ? "false" : "true")}, minimum: {field.MinValue}, maximum: {field.MaxValue})]        
        public long{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        if (int.TryParse(e.Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        {{
            {Table.Name}.{field.Name} = result;
        }}
        else
        {{
            {Table.Name}.{field.Name} = 0;
        }}

        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(StateHasChanged);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""number""
                        step=""1"" 
                        id=""{field.Name.ToLower()}""
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                            Properties_ForImport1 += $@"int {field.Name} = Convert.ToInt32(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                            if(field.Nullable)
                            {
                                PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";
                            }
                            else
                            {
                                PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                            </p>
                                            ";
                            }
                        }
                        else
                        {
                            if (field.Name == "UserCreationId")
                            {
                                PropertiesForEntity +=
$@"        [Range(1, long.MaxValue)]
        public long {field.Name} {{ get; set; }}
";

                                PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""bigint"")
                .IsRequired(true);

            ";
                            }

                            if (field.Name == "UserLastModificationId")
                            {
                                PropertiesForEntity +=
    $@"        [Range(1, long.MaxValue)]
        public long {field.Name} {{ get; set; }}
";

                                PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""bigint"")
                .IsRequired(true);

            ";
                            }
                        }

                        break;
                    //BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN
                    //BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN//BOOLEAN
                    case 4: //Boolean

                        if (field.Name != "Active")
                        {
                            PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""tinyint"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                            PropertiesForEntity +=
$@"        public bool{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""form-check form-switch mb-5 pb-2"">
                        <input class=""form-check-input""
                        type=""checkbox""
                        @bind=""@{Table.Name}!.{field.Name}""
                        id=""{field.Name.ToLower()}"" />
                        <label class=""form-check-label""
                        for=""{field.Name.ToLower()}"">
                            {field.Name}
                        </label>
                    </div>
                    ";

                            Properties_ForImport1 += $@"bool {field.Name} = Convert.ToBoolean(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"@if (@Paginated{Table.Name}DTO.List{Table.Name}[i]!.{field.Name})
                                            {{
                                                <td>
                                                    <span class=""badge rounded-pill bg-success"">Sí</span>
                                                </td>
                                            }}
                                            else
                                            {{
                                                <td>
                                                    <span class=""badge rounded-pill bg-danger"">No</span>
                                                </td>
                                            }}
                                            ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i]!.{field.Name} == true)
                                                {{
                                                    <span class=""badge rounded-pill bg-success"">
                                                        Sí
                                                    </span>
                                                }}
                                                    else if (Paginated{Table.Name}DTO.List{Table.Name}[i]!.{field.Name} == false)
                                                {{
                                                    <span class=""badge rounded-pill bg-danger"">
                                                        No
                                                    </span>
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";
                        }
                        else
                        {
                            PropertiesForEntity +=
$@"        public bool {field.Name} {{ get; set; }}
";

                            PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""tinyint"")
                .IsRequired(true);

            ";
                        }

                        break;
                    //TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC
                    //TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC//TEXT-BASIC
                    case 5: //Text: Basic

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar({field.MaxValue})"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if(ErrorMessage{field.Name} != """")
                            {{
                            @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""text""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    //DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL
                    //DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL//DECIMAL
                    case 6: //Decimal

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        if (decimal.TryParse(e.Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        {{
            {Table.Name}.{field.Name} = result;
        }}
        else
        {{
            {Table.Name}.{field.Name} = 0;
        }}

        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"decimal {field.Name} = Convert.ToDecimal(row.Cell({iForImportInService}).GetString());
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [DecimalRange(required: {(field.Nullable == true ? "false" : "true")}, minimum: {field.MinValue}D, maximum: {field.MaxValue}D)]
        public decimal{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""numeric(18, 2)"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";
                        if(field.Nullable)
                        {
                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";
                        }
                        else
                        {
                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                            </p>
                                            ";
                        }
                        

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""number""
                        step=""0.1""
                        id=""{field.Name.ToLower()}"" 
                        class=""form-control pt-0""
                        @bind-value=""{Table.Name}!.{field.Name}""
                        @bind-value:event=""oninput""
                        @onchange=""Handle{field.Name}Change""/>
                    </div>
                    ";

                        break;
                    //PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK
                    //PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK//PK
                    case 8: //Primary Key (Id)

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>ID</th>
                                    ";

                        PropertiesForEntity +=
$@"[Key]
        public long{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{Table.Name}Id</td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>ID:</b>
                                                @Paginated{Table.Name}DTO.List{Table.Name}[i].{Table.Name}Id
                                            </p>
                                            ";

                        break;
                    //DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME
                    //DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME//DATETIME
                    case 10: //DateTime

                        

                        if (field.Name != "DateTimeCreation" && field.Name != "DateTimeLastModification")
                        {
                            PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""datetime"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                            PropertiesForEntity +=
$@"        [DateTimeRange(required: {(field.Nullable == true ? "false" : "true")}, minimumDate: ""{field.MinValue}"", maximumDate: ""{field.MaxValue}"")]
        public DateTime{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = Convert.ToDateTime(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(StateHasChanged);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""datetime""
                        id=""{field.Name.ToLower()}""
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change""/>
                    </div>
                    ";

                            Properties_ForImport1 += $@"DateTime {field.Name} = Convert.ToDateTime(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                            if (field.Nullable)
                            {
                                PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";
                            }
                            else
                            {
                                PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                            </p>
                                            ";
                            }
                        }
                        else
                        {
                            PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""datetime"")
                .IsRequired(true);

            ";

                            PropertiesForEntity +=
$@"        [DateTimeRange(required: true, minimumDate: ""1753-01-01T12:00"", maximumDate: ""9998-12-30T23:59"")]
        public DateTime {field.Name} {{ get; set; }}
";
                        }
                        break;
                    //TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN
                    //TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN//TIMESPAN
                    case 11: //TimeSpan

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = TimeSpan.Parse(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        //Re-render the page to show ScannedText
        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"TimeSpan {field.Name} = TimeSpan.Parse(row.Cell({iForImportInService}).GetString());
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [TimeSpanRange(required: {(field.Nullable == true ? "false" : "true")}, minimumTime: ""{field.MinValue}"", maximumTime: ""{field.MaxValue}"")]
        public TimeSpan{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""time(7)"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                        if (field.Nullable)
                        {
                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";
                        }
                        else
                        {
                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                            </p>
                                            ";
                        }

                        

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""time""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    //FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK
                    //FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK
                    case 13: //Foreign Key (Id): Options

                        throw new Exception("The Foreign Key (Id) Options property is not allowed in this generator");
                    //HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR
                    //HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR//HEXCOLOUR
                    case 14: //Text: HexColour

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: 6, maximumLength: 6, pattern: """")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar(7)"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                                <span style=""color:@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}"">
                                                    <i class=""fas fa-palette""></i>
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}
                                                </span>
                                            </td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    <span style=""color:#@Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}"">
                                                        <i class=""fas fa-palette""></i>
                                                        #@Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                    </span>
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""color""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    //TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA
                    //TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA//TEXTAREA
                    case 15: //Text: TextArea

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: """")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar(MAX)"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <textarea rows=""10""
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change""
                        id=""{field.Name.ToLower()}"">
                        </textarea>
                    </div>
                    ";

                        break;
                    //TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR
                    //TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR//TEXTEDITOR
                    case 16: //Text: TextEditor 

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: """")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar(MAX)"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<div class=""mb-3"">
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @((MarkupString)Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}!)
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </div>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""quill-editor-{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <div id=""quill-editor-{field.Name.ToLower()}"">
                        </div>
                        <button id=""button-quill-conversion-{field.Name.ToLower()}""
                        type=""button""
                        class=""btn btn-outline-primary my-2"">
                            Convertir a HTML
                        </button>
                        <input type=""text""
                               id=""quill-result-{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    <link rel=""stylesheet"" href=""assets/vendor/quill/dist/quill.snow.css"">
                    <script type=""text/javascript"">
                        var quilleditor{field.Name.ToLower()} = new Quill(""#quill-editor-{field.Name.ToLower()}"", {{
                            theme: 'snow',
                            modules: {{
                                toolbar: {{
                                    container: [
                                        [{{ header: [1, 2, 3, 4, 5, 6, false] }}],
                                        [""bold"", ""italic"", ""underline"", ""strike""],
                                        [{{ list: ""ordered"" }}, {{ list: ""bullet"" }}],
                                        [""link"", ""image"", ""video""],
                                        [""clean""]
                                    ],
                                    handlers: {{
                                        image: imageHandler{field.Name},
                                        video: videoHandler{field.Name}
                                    }}
                                }}
                            }}
                        }});

                        function imageHandler{field.Name}() {{
                            var range = this.quill.getSelection();
                            var value = prompt('Por favor, ingrese la URL de la imagen');
                            if (value) {{
                                this.quill.insertEmbed(range.index, 'image', value, Quill.sources.USER);
                            }}
                        }}

                        function videoHandler{field.Name}() {{
                            var range = this.quill.getSelection();
                            var value = prompt('Por favor, ingrese la URL del video');
                            if (value) {{
                                this.quill.insertEmbed(range.index, 'video', value, Quill.sources.USER);
                            }}
                        }}

                        $(""#button-quill-conversion-{field.Name.ToLower()}"").on(""click"", function () {{
                            var html{field.Name.ToLower()} = quilleditor{field.Name.ToLower()}.root.innerHTML;
                            $(""#quill-result-{field.Name.ToLower()}"").val(html{field.Name.ToLower()})
                        }});

                        $(document).ready(function () {{
                            quilleditor{field.Name.ToLower()}.container.childNodes[0].innerHTML = quilleditor{field.Name.ToLower()}.getText();
                        }});
                    </script>
                    <script src=""assets/vendor/quill/dist/quill.min.js""></script>
                    ";

                        break;
                    //PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD
                    //PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD//PASSWORD
                    case 17: //Text: Password

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]   
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar({field.MaxValue})"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""password""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change""/>
                    </div>
                    ";

                        break;
                    //PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER
                    //PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER//PHONENUMBER
                    case 18: //Text: PhoneNumber

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar({field.MaxValue})"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                                <a class=""nav-link text-info""
                                                   href=""tel:@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}"">
                                                    <b class=""fas fa-phone""></b>
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}
                                                </a>
                                            </td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    <a class=""nav-link text-info px-0""
                                                        href=""tel:@Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}"">
                                                        <i class=""fas fa-phone""></i>
                                                        @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                    </a>
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""tel""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    //URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL
                    //URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL//URL
                    case 19: //Text: URL

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar({field.MaxValue})"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                                <a class=""nav-link text-info""
                                                   href=""@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}""
                                                   target=""_blank"">
                                                    <b class=""fas fa-link""></b>
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}
                                                </a>
                                            </td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    <a class=""nav-link text-info px-0""
                                                        href=""@Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}""
                                                        target=""_blank"">
                                                        <i class=""fas fa-link""></i>
                                                        @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                    </a>
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""url""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    //EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL
                    //EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL//EMAIL
                    case 20: //Text: Email

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar({field.MaxValue})"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                                <a class=""nav-link text-info""
                                                   href=""mailto:@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}"">
                                                    <b class=""fas fa-envelope""></b>
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}
                                                </a>
                                            </td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    <a class=""nav-link text-info px-0""
                                                        href=""mailto:@Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}"">
                                                        <i class=""fas fa-envelope""></i>
                                                        @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                    </a>
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""email""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    //FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE
                    //FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE//FILE
                    case 21: //Text: File

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar(MAX)"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                                <a class=""nav-link text-info""
                                                   href=""@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}""
                                                   download>
                                                    <b class=""fas fa-download""></b>
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}
                                                </a>
                                            </td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    <a class=""nav-link text-info px-0""
                                                        href=""@Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}""
                                                        download>
                                                        <i class=""fas fa-download""></i>
                                                        @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                    </a>
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <InputFile type=""file""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               
                               OnChange=""@Upload{field.Name}"" />
                    </div>
                    ";

                        UploadFileMethod_BlazorNonQueryPage += $@"private async void Upload{field.Name}(InputFileChangeEventArgs e)
    {{

        try
        {{
            string path = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Uploads"",
                ""{Table.Area}"",
                ""{Table.Name}\\"");

            if (!Directory.Exists(path))
            {{
                System.IO.Directory.CreateDirectory(path);
            }}

            long MaxFileSize = 1024L * 1024L * 3; //3MB max.

            await using FileStream FileStream = new(path + e.File.Name, FileMode.Create);
            await e.File.OpenReadStream(MaxFileSize).CopyToAsync(FileStream);

            FileStream.Close();

            string Limitator = ""\\wwwroot"";
            int StartIndex = path.IndexOf(Limitator);
            string Result = """";

            if (StartIndex != -1)
            {{
                Result = path.Substring(StartIndex + Limitator.Length);
            }}

            {Table.Name}!.{field.Name} = Result + e.File.Name;

            Check(""[{field.Name}]"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}

    ";

                        break;
                    //TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG
                    //TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG//TAG
                    case 22: //Text: Tag

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(StateHasChanged);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [String(required: {(field.Nullable == true ? "false" : "true")}, minimumLength: {field.MinValue}, maximumLength: {field.MaxValue}, pattern: ""{field.Regex}"")]
        public string{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}{(field.Nullable == true ? "" : " = string.Empty;")}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""varchar({field.MaxValue})"")
                .IsRequired({(field.Nullable == true ? "false" : "true")});

            ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @if(Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name} != null)
                                                {{
                                                    @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                                }}
                                                else
                                                {{
                                                    <span class=""badge rounded-pill bg-secondary"">
                                                        [NULO]
                                                    </span>
                                                }}
                                            </p>
                                            ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            {(field.Nullable == true ? "" : $@"<span class=""text-danger"">*</span>")}
                            {(field.HistoryUser == "" ? "" : $@"<i class=""fas fa-circle-info"" data-bs-toggle-tooltip=""tooltip"" data-bs-placement=""right"" title=""{field.HistoryUser}""></i>")}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""text""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change""
                               data-toggle=""tags"" />
                    </div>
                    ";

                        break;
                    //FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK
                    //FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK//FK
                    case 23: //Foreign Key (Id): DropDown

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
            entity.Property(e => e.{field.Name})
                .HasColumnType(""bigint"")
                .IsRequired(true);

            ";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            ModalsInBlazorPageNonQuery += $@"<!-- Modal for {field.Name}-->
    <div class=""modal fade"" 
        id=""{field.Name.ToLower()}modal"" 
        tabindex=""-1"" 
        aria-labelledby=""{field.Name.ToLower()}modallabel"" 
        aria-hidden=""true"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""{field.Name.ToLower()}modallabel"">
                        {field.ForeignTableName}
                    </h5>
                </div>
                <div class=""modal-body"">
                    <div class=""input-group input-group-dynamic"">
                        <span class=""input-group-text"">
                            <i class=""fas fa-search"" aria-hidden=""true""></i>
                        </span>
                        <input class=""form-control pt-0""
                                @oninput=""SearchText{field.Name}""
                                type=""search"">
                    </div>
                    <br />
                    <div class=""table-responsive"">
                        <table class=""table table-striped table-hover table-bordered mt-4"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>ID</th>
                                    <th>{field.ForeignColumnName}</th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach ({field.ForeignTableName} {field.ForeignTableName.ToLower()} in List{field.ForeignTableName})
                                {{
                                    <tr>
                                        <td>
                                            <input type=""radio"" 
                                            id=""@{field.ForeignTableName.ToLower()}-{field.ForeignTableName.ToLower()}.{field.Name}"" 
                                            name=""{field.Name.ToLower()}""
                                            value=""@{field.ForeignTableName.ToLower()}.{field.Name}""
                                            @onclick=""@(() => Handle{field.Name}Change({field.ForeignTableName.ToLower()}.{field.Name}))"">
                                        </td>
                                        <td>
                                            @{field.ForeignTableName.ToLower()}.{field.Name}
                                        </td>
                                        <td>
                                            @{field.ForeignTableName.ToLower()}.{field.ForeignColumnName}
                                        </td>
                                    </tr>
                                }}
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class=""modal-footer justify-content-end"">
                    <button type=""button"" 
                    class=""btn btn-dark mb-0"" 
                    data-bs-dismiss=""modal"">
                        Cerrar
                    </button>
                </div>
            </div>
        </div>
    </div>";


                            ForeignLists_DTO += $@"public List<{field.ForeignTableName}> List{field.ForeignTableName} {{ get; init; }} = [];
        ";

                            ForeignUsings_DTO += $@"using {Project.Name}.Areas.{Table.Area}.{field.ForeignTableName}Back.Entities;";

                            ForeignListsGet_BlazorNonQueryPage += $@"List{field.ForeignTableName} = await {field.ForeignTableName.ToLower()}Repository.GetAllBy{field.Name}ForModalAsync("""");
                    ";

                            EditPartFK_BlazorNonQueryPage += $@"{field.ForeignTableName} {field.ForeignTableName} = await {field.ForeignTableName.ToLower()}Repository.GetOneBy{field.Name}Async({Table.Name}.{field.Name});
                    {field.ForeignTableName}{field.ForeignColumnName} = {field.ForeignTableName}.{field.ForeignColumnName};
                    ";

                            ForeignListsDeclaration_BlazorNonQueryPage += $@"private List<{field.ForeignTableName}> List{field.ForeignTableName} {{ get; set; }} = [];
    private string {field.ForeignTableName}{field.ForeignColumnName} {{ get; set; }} = """";
    ";

                            CancelationTokensProperties_BlazorNonQueryPage += $@"private CancellationTokenSource CancellationTokenSourceFor{field.ForeignTableName}ModalSearchBar = new();
    ";

                            Injections_BlazorNonQueryPage += $@"@using {Project.Name}.Areas.{Table.Area}.{field.ForeignTableName}Back.Entities;
@using {Project.Name}.Areas.{Table.Area}.{field.ForeignTableName}Back.Repositories;
@inject {field.ForeignTableName}Repository {field.ForeignTableName.ToLower()}Repository;
";

                            PropertiesForEntity +=
$@"        [Range(1, long.MaxValue)]
        public long{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";

                            Searchers_BlazorNonQueryPage += $@"private async Task SearchText{field.Name}(ChangeEventArgs args)
    {{
        CancellationTokenSourceFor{field.ForeignTableName}ModalSearchBar.Cancel();
        CancellationTokenSourceFor{field.ForeignTableName}ModalSearchBar = new();

        try
        {{
            await Task.Delay(300, CancellationTokenSourceFor{field.ForeignTableName}ModalSearchBar.Token);

            string TextToSearch = args.Value.ToString();

            List{field.ForeignTableName} = await {field.ForeignTableName.ToLower()}Repository.GetAllBy{field.Name}ForModalAsync(TextToSearch);
        }}
        catch (TaskCanceledException)
        {{
            //User still writing, do nothing and wait for the next event to trigger
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}
    ";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(long {field.Name.ToLower()})
    {{
        {Table.Name}.{field.Name} = {field.Name.ToLower()};
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        {field.ForeignTableName} {field.ForeignTableName} = await {field.ForeignTableName.ToLower()}Repository.GetOneBy{field.Name}Async({Table.Name}.{field.Name});
        {field.ForeignTableName}{field.ForeignColumnName} = {field.ForeignTableName}.{field.ForeignColumnName};

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        //Re-render the page to show ScannedText
        await InvokeAsync(StateHasChanged);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static"">
                        <label>
                            {field.Name}
                            <span class=""text-danger"">*</span>
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""text""
                               readonly
                               class=""form-control pt-0""
                               @bind=""{field.ForeignTableName}{field.ForeignColumnName}""/>
                        <input type=""hidden""
                               id=""{field.Name.ToLower()}""
                               value=""@{Table.Name}!.{field.Name}""/>
                    </div>
                    <button type=""button"" 
                    class=""btn btn-dark mb-5 pb-2"" 
                    data-bs-toggle=""modal"" 
                    data-bs-target=""#{field.Name.ToLower()}modal"">
                        Seleccionar
                    </button>
                    ";

                            Properties_ForImport1 += $@"int {field.Name} = Convert.ToInt32(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@Paginated{Table.Name}DTO.List{Table.Name}[i]?.{field.Name}</td>
                                            ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                    ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p>
                                                <b>{field.Name}:</b>
                                                <br />
                                                @Paginated{Table.Name}DTO.List{Table.Name}[i].{field.Name}
                                            </p>
                                            ";
                        }
                        else
                        {
                            PropertiesForEntity +=
$@"        [Range(1, long.MaxValue)]
        public long{(field.Nullable == true ? "?" : "")} {field.Name} {{ get; set; }}
";
                        }

                        break;
                    default:
                        throw new Exception("ERROR localizing Data Type: The Data Type identificator is not correct");
                }
                PropertiesForEntity += Environment.NewLine;
            }
            PropertiesForEntity = PropertiesForEntity.TrimEnd('\n', '\r', '\n', '\r');
            PropertiesForRepository_DataTable = PropertiesForRepository_DataTable.TrimEnd('\t', '\t', '\t', '\t', '\t', '\r', ',');
        }
    }
}
