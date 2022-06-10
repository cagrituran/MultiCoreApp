using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MultiCoreApp.API.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            return modelState.SelectMany(x=>x.Value.Errors).Select(x=> x.ErrorMessage).ToList();
        }
    }
}
