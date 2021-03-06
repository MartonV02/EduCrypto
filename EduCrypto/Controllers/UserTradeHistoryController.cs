using Application.Common;
using Application.Common.Auth;
using Application.UserCrypto;
using Application.UserForGroups;
using Application.UserHandling;
using Application.UserTradeHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserTradeHistoryController : Controller
    {
        private readonly IConfiguration config;
        private readonly UserTradeHistoryAppService userTradeHistoryAppService;
        private readonly UserHandlingAppService userHandlingAppService;
        private readonly UserForGroupsAppService userForGroupsAppService;
        private readonly UserCryptoAppService userCryptoAppService;

        public UserTradeHistoryController(ApplicationDbContext dbContext, IConfiguration config)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userTradeHistoryAppService = new UserTradeHistoryAppService(dbContext);
            userHandlingAppService = new UserHandlingAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
            userCryptoAppService = new UserCryptoAppService(dbContext);
            this.config = config;
        }

#if DEBUG
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<UserTradeHistoryModel> GetAll()
        {
            return userTradeHistoryAppService.GetAll();
        }
#endif

        [HttpGet("{userId}")]
        public ActionResult GetByUserId(int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.GetUserIdFromToken(config, token) != userId)
                return Forbid();

            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.GetByUserId(userId));
            });
        }

        [HttpGet("group/{groupId}")]
        public ActionResult GetByGroupId(int groupId)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            return this.Run(() =>
            {
                if (!userForGroupsAppService.IsMember(groupId, AuthenticationExtension.GetUserIdFromToken(config, token)))
                    return Forbid();
                return Ok(userTradeHistoryAppService.GetByGroupId(groupId));
            });
        }

        [HttpGet("{userId}/{groupId}")]
        public ActionResult GetByUserAndGroupId(int userId, int groupId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (!userForGroupsAppService.IsMember(groupId, AuthenticationExtension.GetUserIdFromToken(config, token)))
                return Forbid();

            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.GetByUserAndGroupId(userId, groupId));
            });
        }

        [HttpPut]
        public ActionResult Create(UserTradeHistoryModel userTradeHistoryModel)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.GetUserIdFromToken(config, token) != userTradeHistoryModel.userHandlingModelId)
                return Forbid();

            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.CreateWithTransaction(userTradeHistoryModel, this.userHandlingAppService, 
                    this.userCryptoAppService, this.userForGroupsAppService));
            });
        }
    }
}
