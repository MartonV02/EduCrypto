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
                return controller.BadRequest(new
                {
#if DEBUG
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace
#else
                    ErrorMessage = "Unexpected Error"
#endif
                });
            }
        }
    }
}
