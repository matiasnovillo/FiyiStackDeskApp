namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string InterfaceRepositoryCustom(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces
{{
    public partial interface I{Table.Name}Repository
    {{
        //Put your custom code here
        #region Async Queries

        #endregion

        #region Async Non-Queries

        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
