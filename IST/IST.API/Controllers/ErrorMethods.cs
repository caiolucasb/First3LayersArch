using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace IST.API.Controllers
{
    public static class ErrorMethods
    {
        public static IActionResult InternalServerError(this ControllerBase controller, Exception exception)
        {
            return controller.StatusCode((int)HttpStatusCode.InternalServerError, new { Message = exception.Message });
        }

        public static IActionResult InternalServerError(this ControllerBase controller, string errorMessage)
        {
            return controller.StatusCode((int)HttpStatusCode.InternalServerError, new { Message = errorMessage });
        }

        public static IActionResult BadRequestError(this ControllerBase controller, string errorMessage)
        {
            return controller.StatusCode((int)HttpStatusCode.BadRequest, new { Message = errorMessage });
        }
    }
}