using Application.Common;
using Application.Group;
using Application.UserForGroups;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        readonly GroupAppService groupAppService;
        readonly UserForGroupsAppService userForGroupsAppService;
        readonly UserHandlingAppService userHandlingAppService;

        public GroupController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            groupAppService = new GroupAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
            userHandlingAppService = new UserHandlingAppService(dbContext);
        }

        [HttpGet]
        public IEnumerable<GroupModel> GetAll()
        {
            return groupAppService.GetAll();
        }

        [HttpGet("groupId")]
        public ActionResult GetById(int groupId)
        {
            return this.Run(() =>
            {
                return Ok(groupAppService.GetById(groupId));
            });
        }

        [HttpPut("{userId}")]
        public ActionResult Create(int userId, GroupModel groupModel)
        {
            return this.Run(() =>
            {
                GroupModel group = groupAppService.Create(groupModel);
                UserHandlingModel user = userHandlingAppService.GetById(userId);
                UserForGroupsModel userForGroupsModel = new UserForGroupsModel()
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
            return this.Run(() =>
            {
                return Ok(groupAppService.Update(groupModel));
            });
        }

        [HttpDelete]
        public ActionResult Delete(GroupModel groupModel)
        {
            return this.Run(() =>
            {
                groupAppService.Delete(groupModel.Id);
                return Ok();
            });
        }
    }
}
