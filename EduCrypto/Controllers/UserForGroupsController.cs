using Application.Common;
using Application.Common.Auth;
using Application.Group;
using Application.UserForGroups;
using Application.UserHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserForGroupsController : Controller
    {
        private readonly IConfiguration config;
        private readonly UserForGroupsAppService userForGroupsAppService;
        private readonly GroupAppService groupAppService;
        private readonly UserHandlingAppService userHandlingAppService;

        public UserForGroupsController(ApplicationDbContext dbContext, IConfiguration config)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userHandlingAppService = new UserHandlingAppService(dbContext);
            groupAppService = new GroupAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
            this.config = config;
        }

#if DEBUG
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAll()
        {
            return this.Run(() =>
            {
                return Ok(userForGroupsAppService.GetAll());
            });
        }
#endif

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            return this.Run(() =>
            {
                var userForGrooups = userForGroupsAppService.GetById(id);

                if (AuthenticationExtension.GetUserIdFromToken(config, token) != userForGrooups.userHandlingModelId)
                    return Forbid();
                return Ok(userForGrooups);
            });
        }

        [HttpGet("user/{userId}")]
        public ActionResult GetByUserId(int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.GetUserIdFromToken(config, token) != userId)
                return Forbid();

            return this.Run(() =>
            {
                return Ok(userForGroupsAppService.GetByUserId(userId));
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
                return Ok(userForGroupsAppService.GetByGroupId(groupId));
            });
        }

        [HttpPut("join/{code}/{userId}")]
        public ActionResult Join(string code, int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.GetUserIdFromToken(config, token) != userId)
                return Forbid();

            return this.Run(() =>
            {

                string[] s = code.Split('-');
                try
                {
                    int id = Convert.ToInt32(s[1]);
                    string name = s[0];
                    GroupModel group = groupAppService.GetById(id);
                    if (userForGroupsAppService.GetByUserId(userId).Where(e => e.groupModelId == id).FirstOrDefault() != null)
                    {
                        throw new Exception();
                    }

                    if (group.name == name)
                    {
                        UserHandlingModel user = userHandlingAppService.GetById(userId);
                        UserForGroupsModel userForGroups = new() { 
                            userHandlingModelId = user.Id,
                            groupModelId = group.Id,
                            accesLevel = "member",
                            money = group.startBudget,
                        };

                        return Ok(userForGroupsAppService.Create(userForGroups));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    return BadRequest(new
                    {
                        ErrorMessage = "There is no such a goup with that name and Id, or you have already joint that group"
                    });
                }
            });
        }
    }
}
