using Application.Common;
using Application.Common.Auth;
using Application.Group;
using Application.UserForGroups;
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
    public class GroupController : Controller
    {
        private readonly IConfiguration config;
        private readonly GroupAppService groupAppService;
        private readonly UserForGroupsAppService userForGroupsAppService;
        private readonly UserHandlingAppService userHandlingAppService;

        public GroupController(ApplicationDbContext dbContext, IConfiguration config)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            groupAppService = new GroupAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
            userHandlingAppService = new UserHandlingAppService(dbContext);
            this.config = config;
        }

#if DEBUG
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<GroupModel> GetAll()
        {
            return groupAppService.GetAll();
        }
#endif

        [HttpGet("{groupId}")]
        public ActionResult GetById(int groupId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (!userForGroupsAppService.IsMember(groupId, AuthenticationExtension.getUserIdFromToken(config, token)))
                return Forbid();

            return this.Run(() =>
            {
                return Ok(groupAppService.GetById(groupId));
            });
        }

        [HttpPut("{userId}")]
        public ActionResult Create(int userId, GroupModel groupModel)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.getUserIdFromToken(config, token) != userId)
                return Forbid();

            return this.Run(() =>
            {
                GroupModel group = groupAppService.Create(groupModel);
                UserHandlingModel user = userHandlingAppService.GetById(userId);
                UserForGroupsModel userForGroupsModel = new()
                {
                    userHandlingModelId = user.Id,
                    groupModelId = group.Id,
                    accesLevel = "creator",
                    money = group.startBudget,
                };

                userForGroupsAppService.Create(userForGroupsModel);

                return Ok(group);
            });
        }

        [HttpPost]
        public ActionResult Modify(GroupModel groupModel)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (!userForGroupsAppService.IsCreator(groupModel.Id, AuthenticationExtension.getUserIdFromToken(config, token)))
                return Forbid();

            return this.Run(() =>
            {
                return Ok(groupAppService.Update(groupModel));
            });
        }

        [HttpDelete("{groupId}")]
        public ActionResult Delete(int groupId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (!userForGroupsAppService.IsCreator(groupId, AuthenticationExtension.getUserIdFromToken(config, token)))
                return Forbid();

            return this.Run(() =>
            {
                groupAppService.Delete(groupId);
                return Ok("Group Succesfuly deleted");
            });
        }
    }
}
