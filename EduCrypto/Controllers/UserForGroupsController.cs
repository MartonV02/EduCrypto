using Application.Common;
using Application.Group;
using Application.UserForGroups;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserForGroupsController : Controller
    {
        readonly UserForGroupsAppService userForGroupsAppService;
        readonly GroupAppService groupAppService;
        readonly UserHandlingAppService userHandlingAppService;

        public UserForGroupsController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userHandlingAppService = new UserHandlingAppService(dbContext);
            groupAppService = new GroupAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return this.Run(() =>
            {
                return Ok(userForGroupsAppService.GetById(id));
            });
        }

        [HttpGet("user/{userId}")]
        public ActionResult GetByUserId(int userId)
        {
            return this.Run(() =>
            {
                return Ok(userForGroupsAppService.GetByUserId(userId));
            });
        }

        [HttpGet("group/{groupId}")]
        public ActionResult GetByGroupId(int groupId)
        {
            return this.Run(() =>
            {
                return Ok(userForGroupsAppService.GetByGroupId(groupId));
            });
        }

        [HttpPut("{code}/{userId}")]
        public ActionResult Join(string code, int userId)
        {
            return this.Run(() =>
            {
                string[] s = code.Split('#');
                int id = Convert.ToInt32(s[1]);
                string name = s[0];
                GroupModel group = groupAppService.GetById(id);

                if (group.name == name)
                {
                    UserForGroupsModel userForGroups = new UserForGroupsModel();
                    UserHandlingModel user = userHandlingAppService.GetById(userId);

                    userForGroups.userHandling = user;
                    userForGroups.group = group;
                    userForGroups.accesLevel = "member";
                    userForGroups.money = group.startBudget;

                    return Ok(userForGroupsAppService.Create(userForGroups));
                }
                return BadRequest(new
                {
                    ErrorMessage = "There is no such a goup with \"" + name + "\" name, and \"" + id + "\" id"
                });
            });
        }
    }
}
