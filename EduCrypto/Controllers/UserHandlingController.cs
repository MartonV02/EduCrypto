using Application.Common;
using Application.Common.Auth;
using Application.UserHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserHandlingController : Controller
    {
        private IConfiguration config;
        readonly UserHandlingAppService userHandlingAppService;

        public UserHandlingController(ApplicationDbContext dbContext, IConfiguration config)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userHandlingAppService = new UserHandlingAppService(dbContext);
            this.config = config;
        }

#if DEBUG
        [HttpGet]
        public IEnumerable<UserHandlingModel> GetAll()
        {
            return userHandlingAppService.GetAll();
        }
#endif

        [HttpGet("{userId}")]
        public ActionResult GetById(int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.getUserIdFromToken(config, token) != userId)
                return Forbid();
            return this.Run(() =>
            {
                return Ok(userHandlingAppService.GetById(id));
            });
        }

        [HttpPut]
        public ActionResult Create(UserHandlingModel user)
        {
            return this.Run(() =>
            {
                UserHandlingModel result = userHandlingAppService.Create(user);
                return Ok(new
                {
                    result.Id,
                    result.userName,
                    result.email,
                    result.fullName,
                    result.birthDate,
                    result.moneyDollar,
                    result.xpLevel,
                });
            });
        }

        [HttpPost]
        public ActionResult Modify(UserHandlingModel user)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.getUserIdFromToken(config, token) != user.Id)
                return Forbid();
            return this.Run(() =>
            {
                UserHandlingModel modified = userHandlingAppService.GetById(user.Id);
                modified.Id = user.Id;
                modified.userName = user.userName;
                modified.email = user.email;
                modified.fullName = user.fullName;
                modified.birthDate = user.birthDate;
                modified.Password = user.Password;
                UserHandlingModel result = userHandlingAppService.Update(modified);
                return Ok(new
                {
                    result.Id,
                    result.userName,
                    result.email,
                    result.fullName,
                    result.birthDate,
                    result.moneyDollar,
                    result.xpLevel,
                });
            });
        }

        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.getUserIdFromToken(config, token) != userId)
                return Forbid();
            return this.Run(() =>
            {
                userHandlingAppService.Delete(userId);
                return Ok("Succesfull delete");
            });
        }

    }
}
