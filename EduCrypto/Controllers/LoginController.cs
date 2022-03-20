using Application.Common;
using Application.Common.Auth;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration config;
        private readonly UserHandlingAppService userAppService;
        public LoginController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            userAppService = new UserHandlingAppService(dbContext);
            config = configuration;
        }

        [HttpPost]
        public ActionResult Login(dynamic model)
        {
            return this.Run(() =>
            {
                string email = ((JsonElement)model).GetProperty("email").GetString();
                string password = ((JsonElement)model).GetProperty("password").GetString();

                UserHandlingModel user = userAppService.GetByEmail(email);
                if (user == null || !user.CheckPassword(password))
                    return Forbid();

                var jwt = new JwtService(config);
                var token = jwt.GenerateSecurityToken(email, user.Id);
                return Ok(new
                {
                    token
                });
            });
        }
    }
}
