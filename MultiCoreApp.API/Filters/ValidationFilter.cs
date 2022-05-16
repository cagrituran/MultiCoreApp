using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MultiCoreApp.API.DTOs;

namespace MultiCoreApp.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(x => x.Errors);
                modelErrors.ToList().ForEach(x =>
                {
                    errorDto.Errors.Add(x.ErrorMessage + "benimhatam la");
                });
                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
