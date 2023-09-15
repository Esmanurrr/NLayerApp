using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if there are errors
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                //400 - client, 500 - server
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors)); // send error message in the response body -  if it is BadRequestResult it will empty in body


            }
        }
    }
}
