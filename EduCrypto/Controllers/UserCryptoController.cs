using Application.Common;
using Application.Common.Auth;
using Application.UserCrypto;
using Application.UserForGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserCryptoController : Controller
    {
        private readonly IConfiguration config;
        private readonly UserCryptoAppService userCryptoAppService;
        private readonly UserForGroupsAppService userForGroupsAppService;

        public UserCryptoController(ApplicationDbContext dbContext, IConfiguration config)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            this.userCryptoAppService = new UserCryptoAppService(dbContext);
            this.userForGroupsAppService = new UserForGroupsAppService(dbContext);
            this.config = config;
        }

#if DEBUG
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return this.Run(() =>
            {
                var result = userCryptoAppService.GetAll();

                return Ok(result);
            });
        }
#endif

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            return this.Run(() =>
            {
                var result = userCryptoAppService.GetById(id);

                if (AuthenticationExtension.GetUserIdFromToken(config, token) != result.userHandlingModelId)
                    return Forbid();
                return Ok(result);
            });
        }

        [HttpGet("userForGroup/{userForGroupId:int}")] //TODO I'm not sure we need this, the one below this is for the same purpose
        public IActionResult GetByUserForGroupsId(int userForGroupId)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            return this.Run(() =>
            {
                var userForGroup = userForGroupsAppService.GetById(userForGroupId);
                if (userForGroupsAppService.IsMember(userForGroup.groupModelId, AuthenticationExtension.GetUserIdFromToken(config, token)))
                    return Forbid();

                return Ok(userCryptoAppService.GetByUserForGroupsId(userForGroupId));
            });
        }

        [HttpGet("group/{groupId:int}")]
        public IActionResult GetByGroupId(int groupId)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            return this.Run(() =>
            {
                if (userForGroupsAppService.IsMember(groupId, AuthenticationExtension.GetUserIdFromToken(config, token)))
                    return Forbid();

                return Ok(userCryptoAppService.GetByGroupId(groupId));
            });
        }

        [HttpGet("Group/{groupId}/User/{userId}")]
        public IActionResult GetByGroupAndUserId(int groupId, int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            return this.Run(() =>
            {
                if (userForGroupsAppService.IsMember(groupId, AuthenticationExtension.GetUserIdFromToken(config, token)))
                    return Forbid();

                return Ok(userCryptoAppService.GetByGroupAndUserId(groupId, userId));
            });
        }
    }
}
