using System.ComponentModel.DataAnnotations;
using System.Net;
using OSRSWeapons.Exceptions;
using OSRSWeapons.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace OSRSWeapons.Configurations {

    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Create our ErrorDetails. For now we are just creating a very generic 500 error with a generic message
            // as an example.
            ErrorDetails errorDetails = new();

            if (exception is EntityNotFoundException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.NotFound;
                errorDetails.Message = "Item could not be found";
                errorDetails.ExceptionMessage = exception.Message;
            } 
            else if (exception is NoCriteriaMatchException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.Accepted;
                errorDetails.Message = "Search completed successfully but returned no results.";
                errorDetails.ExceptionMessage = exception.Message;
            }
            else if (exception is WeaponUnmodifiableException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.BadRequest;
                errorDetails.Message = "That item is marked as unmodifiable.";
                errorDetails.ExceptionMessage = exception.Message;
            }
            else if (exception is WeaponUpdateException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.BadRequest;
                errorDetails.Message = "Weapon failed to update.";
                errorDetails.ExceptionMessage = exception.Message;
            }
            else if (exception is ValidationException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.BadRequest;
                errorDetails.Message = "Validation errors have occurred.";
                errorDetails.ExceptionMessage = exception.Message;
            }
             else 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.InternalServerError;
                errorDetails.Message = "Something went wrong.";
                errorDetails.ExceptionMessage = exception.Message;
            }

            // Set the status code of the HTTP Response and the Content Type of the HTTP Response.
            httpContext.Response.StatusCode = errorDetails.StatusCode;
            httpContext.Response.ContentType = "application/json";
            
            // Write our error details as JSON for the response body.
            await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);

            // Return true as we have successfully handled our exception.
            return true;
        }
    }

}