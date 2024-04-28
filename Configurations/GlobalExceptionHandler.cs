using System.ComponentModel.DataAnnotations;
using System.Net;
using OSRSWeapons.Exceptions;
using OSRSWeapons.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace OSRSWeapons.Configurations {

    /// <summary>
    /// Constructor for WeaponsController
    /// </summary>
    /// <author>Josh Faber</author>
    /// <param name="weaponsService">Instance of WeaponsService</param>
    public class GlobalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Tries to handle an exception and generate an appropriate error response
        /// </summary>
        /// <param name="httpContext">The HttpContext associated with the request</param>
        /// <param name="exception">The exception that occurred</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the exception was handled successfully; otherwise, false</returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorDetails errorDetails = new();

            if (exception is EntityNotFoundException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.NotFound;
                errorDetails.Message = "Item could not be found.";
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
            else if (exception is WeaponDeleteException) 
            {
                errorDetails.StatusCode = (int) HttpStatusCode.BadRequest;
                errorDetails.Message = "Weapon failed to delete.";
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

            // Set the status code of the HTTP Response and the Content Type of the HTTP Response
            httpContext.Response.StatusCode = errorDetails.StatusCode;
            httpContext.Response.ContentType = "application/json";
            
            // Write our error details as JSON for the response body
            await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);

            // Return true as we have successfully handled our exception
            return true;
        }
    }
}
