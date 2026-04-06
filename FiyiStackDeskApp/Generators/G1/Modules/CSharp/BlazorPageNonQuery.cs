namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string BlazorPageNonQuery(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"@page ""/cms/{Table.Area.ToLower()}/{Table.Name.ToLower()}nonquerypage/{{{Table.Name}Id:int}}""

@inherits {GeneratorConfigurationComponent.ChosenProject.Name}.Components.Base.CMSBase;

@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Repositories;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;

@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;
@inject IJSRuntime IJSRuntime;

<!--FOREIGN CALLS (TABLES)-->
{GeneratorConfigurationComponent.G1FieldChainer.Injections_BlazorNonQueryPage}

@if ({Table.Name}Id == 0)
{{
    <PageTitle>Agregar {Table.Name.ToLower()} - {Table.Area}</PageTitle>
}}
else
{{
    <PageTitle>Editar {Table.Name.ToLower()} - {Table.Area}</PageTitle>
}}

<{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._SideNavForDashboard lstFoldersAndPagesForSideNavDTO=""lstFoldersAndPagesForSideNavDTO""></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._SideNavForDashboard>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._NavBarForDashboard Pagina=""{Table.Name}""></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._NavBarForDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
             style=""background-image: url('img/System/Landscape.jpg');"">
            <span class=""mask bg-gradient-dark opacity-6""></span>
        </div>
        <div class=""card card-body mx-3 mx-md-4 mt-n6"">
            <div class=""card-header mb-0 pb-0 px-4"">
                <div class=""d-flex flex-column flex-md-row justify-content-between align-items-start align-items-md-center"">
                    <h3 class=""mb-3 mb-md-0"">
                        @if ({Table.Name}Id == 0)
                        {{
                            <span>Agregar {Table.Name.ToLower()}</span>
                        }}
                        else
                        {{
                            <span>Editar {Table.Name.ToLower()}</span>
                        }}
                    </h3>
                    <div class=""d-flex"">
                        <NavLink class=""btn btn-white btn-sm"" href=""CMS/{Table.Area}/{Table.Name}QueryPage"">
                            <span class=""fas fa-chevron-left""></span>
                            &nbsp;
                            Volver
                        </NavLink>
                    </div>
                </div>
                <div class=""alert alert-info text-white"" role=""alert"">
                    Los campos marcados con <span class=""text-danger"">*</span> son obligatorios
                </div>
                <hr class=""mt-3"" />
            </div>
            <div class=""card-body px-4"">
                <form method=""post"" @onsubmit=""Submit""
                      @formname=""{Table.Name.ToLower()}-form"" class=""mb-4"">
                    <AntiforgeryToken />
                    {GeneratorConfigurationComponent.G1FieldChainer.PropertiesInHTML_BlazorNonQueryPage}
                    <hr />
                    @((MarkupString)Message)
                    <div class=""d-flex justify-content-between"">
                        <button id=""btn-submit"" 
                        type=""submit""
                        class=""btn btn-success""
                        disabled=""@IsSubmitting"">
                            @if (IsSubmitting)
                            {{
                                <i class=""fas fa-spinner fa-spin""></i>
                                <span>&nbsp;Guardando...</span>
                            }}
                            else
                            {{
                                <i class=""fas fa-pen""></i>
                                <span>&nbsp;@({Table.Name}Id == 0 ? ""Agregar"" : ""Editar"")</span>
                            }}
                        </button>
                        <NavLink class=""btn btn-white mx-3"" href=""CMS/{Table.Area}/{Table.Name}QueryPage"">
                            <span class=""fas fa-chevron-left""></span>
                            &nbsp;Volver
                        </NavLink>
                    </div>
                </form>
                
            </div>
        </div>
    </div>
    <!-- MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS -->
    <!-- MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS MODALS FOR FOREIGN KEYS -->
    {GeneratorConfigurationComponent.G1FieldChainer.ModalsInBlazorPageNonQuery}

    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FixedPluginForDashboard></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FixedPluginForDashboard>
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FooterForDashboard></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FooterForDashboard>
</div>

@code {{

    //PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIESPROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES
    //PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIESPROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES

    #region Properties
    private List<folderAndPagesForCMSDTO> lstFoldersAndPagesForSideNavDTO = [];

    [Parameter]
    public int {Table.Name}Id {{ get; set; }}

    private string Message {{ get; set; }} = """";

    [SupplyParameterFromForm]
    private {Table.Name} {Table.Name} {{ get; set; }} = new();

    private bool IsSubmitting = false;

    //Error messages for inputs
    {GeneratorConfigurationComponent.G1FieldChainer.ErrorMessage_InNonQueryBlazor}
    
    //FOREIGN LISTS (TABLES)
    {GeneratorConfigurationComponent.G1FieldChainer.ForeignListsDeclaration_BlazorNonQueryPage}

    //CANCELATION TOKENS
    {GeneratorConfigurationComponent.G1FieldChainer.CancelationTokensProperties_BlazorNonQueryPage}
    #endregion

    protected override void OnInitialized()
    {{
    }}

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {{
        try
        {{
            if (firstRender)
            {{
                await base.GetUserIdFromCookies();

                await base.IsUserAvailableToUseThisPage(""/CMS/{Table.Area}/{Table.Name}QueryPage"");

                lstFoldersAndPagesForSideNavDTO = await rolemenuRepository
                    .GetAllPagesAndFoldersForCMSByRoleIdAsync(base.User!.RoleId);

                //FOREIGN LISTS (TABLES)
                {GeneratorConfigurationComponent.G1FieldChainer.ForeignListsGet_BlazorNonQueryPage}

                if ({Table.Name}Id == 0)
                {{
                    //Create new {Table.Name}
                    {Table.Name} = new();
                }}
                else
                {{
                    //Edit {Table.Name}

                    {Table.Name} = await {Table.Name.ToLower()}Repository
                                .GetOneBy{Table.Name}IdAsync({Table.Name}Id);

                    {GeneratorConfigurationComponent.G1FieldChainer.EditPartFK_BlazorNonQueryPage}
                }}  


                Check("""");
                
            }}
        }}
        catch (Exception ex)
        {{
            await base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task Submit()
    {{
        try
        {{
            if (IsSubmitting)
            {{
                return;
            }}

            IsSubmitting = true;
            await InvokeAsync(StateHasChanged);

            if(Check("""") != null)
            {{
                await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""No se puede guardar. Hay campos faltantes. Operación cancelada."", ""warning"");
                return;
            }}

            if ({Table.Name}Id == 0)
            {{
                //Create new {Table.Name}
                {Table.Name}.Active = true;
                {Table.Name}.UserCreationId = User.UserId;
                {Table.Name}.UserLastModificationId = User.UserId;
                {Table.Name}.DateTimeCreation = DateTime.Now;
                {Table.Name}.DateTimeLastModification = DateTime.Now;

                await {Table.Name.ToLower()}Repository
                    .AddAsync({Table.Name});
  
            }}
            else
            {{
                //Update data
                {Table.Name}.DateTimeLastModification = DateTime.Now;
                {Table.Name}.UserLastModificationId = User.UserId;

                await {Table.Name.ToLower()}Repository
                    .UpdateAsync({Table.Name});
            }}
            
            NavigationManager.NavigateTo(""/cms/{Table.Area.ToLower()}/{Table.Name.ToLower()}querypage"");
        }}
        catch (Exception ex)
        {{
            await base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            IsSubmitting = false;

            await InvokeAsync(StateHasChanged);
        }}
    }}

    //UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERSUPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS 
    //UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERSUPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS UPLOADERS 

    #region Uploaders
    {GeneratorConfigurationComponent.G1FieldChainer.UploadFileMethod_BlazorNonQueryPage}
    #endregion   

    //SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLESSEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN 
    //SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN TABLESSEARCHERS FOR FOREIGN TABLES SEARCHERS FOR FOREIGN 

    #region SEARCHERS FOR FOREIGN TABLES
    {GeneratorConfigurationComponent.G1FieldChainer.Searchers_BlazorNonQueryPage}
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""attributeToValid"">Debe estar encapsulado en []. Ejemplo: [Boolean]</param>
    /// <returns></returns>
    private ValidationResult Check(string attributeToValid)
    {{
        try
        {{
            List<ValidationResult> lstValidationResult = new List<ValidationResult>();
            ValidationContext ValidationContext = new ValidationContext({Table.Name});

            bool IsValid = Validator.TryValidateObject({Table.Name}, ValidationContext, lstValidationResult, true);

            ValidationResult ValidationResult = lstValidationResult
            .AsQueryable()
            .FirstOrDefault(x => x.ErrorMessage.StartsWith(attributeToValid));

            if (!IsValid)
            {{
                Message = $@""<div class=""""alert alert-warning text-white"""" role=""""alert"""">
                                Para guardar correctamente debe completar los siguientes puntos: <br/> <ul>"";

                foreach (var validationResult in lstValidationResult)
                {{
                    validationResult.ErrorMessage = validationResult.ErrorMessage.Substring(validationResult.ErrorMessage.IndexOf(']') + 1);
                    Message += $@""<li>{{validationResult}}</li>"";
                }}

                Message = Message + ""</ul></div>"";
            }}
            else
            {{
                Message = $@""<div class=""""alert alert-successs text-white"""" role=""""alert"""">
                                Todos los datos ingresados son correctos
                            </div>"";
            }}


            if (ValidationResult != null)
            {{
                ValidationResult.ErrorMessage = ValidationResult.ErrorMessage.Substring(ValidationResult.ErrorMessage.IndexOf(']') + 1);
            }}

            return ValidationResult;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            return null;
        }}
        finally
        {{

        }}
    }}

    //HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE
    //HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE HANDLERS OF CHANGE

    #region Handlers
    {GeneratorConfigurationComponent.G1FieldChainer.Handlers_InNonQueryBlazor}
    #endregion
}}

";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
