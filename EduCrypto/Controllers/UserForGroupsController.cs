using Application.Common;
using Application.Group;
using Application.UserForGroups;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using System;

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
                try
                {
                    int id = Convert.ToInt32(s[1]);
                    string name = s[0];
                    GroupModel group = groupAppService.GetById(id);

                    if (group.name == name)
                    {
                        UserHandlingModel user = userHandlingAppService.GetById(userId);
                        UserForGroupsModel userForGroups = new UserForGroupsModel() { 
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
                        ErrorMessage = "There is no such a goup with \"" + s[0] + "\" name, and \"" + s[1] + "\" id"
                    });
                }
            });
        }
    }
}
