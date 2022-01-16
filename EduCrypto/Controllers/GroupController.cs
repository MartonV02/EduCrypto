using Application.Common;
using Application.Group;
using Application.UserForGroups;
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

        public GroupController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            groupAppService = new GroupAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
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

        [HttpPut]
        public ActionResult Create(GroupModel groupModel, UserForGroupsModel userForGroupsModel)
        {
            return this.Run(() =>
            {
                userForGroupsModel.group = groupModel;
                userForGroupsModel.accesLevel = "creator";
                userForGroupsModel.money = groupModel.startBudget;

                userForGroupsAppService.Create(userForGroupsModel);

                return Ok(groupAppService.Create(groupModel));
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
