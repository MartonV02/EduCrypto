using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCrypto.Controllers
{
    public static class Extensions
    {
        public static ActionResult Run(this ControllerBase controller, Func<ActionResult> function)
        {
            try
            {
                return function();
            }
            catch (KeyNotFoundException)
            {
                return controller.StatusCode(501, new
                {
                    ErrorMessage = "Not existing identifier"
                });
            }
            catch (Exception ex)
            {
#if DEBUG
                var errorMessage = ex.Message;
                while (ex.InnerException != null)
                {
                    errorMessage += $"\n {ex.InnerException.Message}";
                    ex = ex.InnerException;
                }
                return controller.BadRequest(new
                {
                    ErrorMessage = errorMessage,
                    StackTrace = ex.StackTrace

                });
#else
                return controller.BadRequest(new 
                {
                    ErrorMessage = "Unexpected Error"
                });
#endif
            }
        }
    }
}
