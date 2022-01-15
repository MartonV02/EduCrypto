using Application.Common;
using Application.UserTradeHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTradeHistoryController : Controller
    {
        readonly UserTradeHistoryAppService userTradeHistoryAppService;

        public UserTradeHistoryController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userTradeHistoryAppService = new UserTradeHistoryAppService(dbContext);
        }

        [HttpGet]
        public IEnumerable<UserTradeHistoryModel> GetAll()
        {
            return userTradeHistoryAppService.GetAll();
        }

        [HttpGet("{userId}")]
        public ActionResult GetByUserId(int userId)
        {
            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.GetByUserId(userId));
            });
        }

        [HttpGet("group/{groupId}")]
        public ActionResult GetByGroupId(int groupId)
        {
            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.GetByGroupId(groupId));
            });
        }

        [HttpGet("{userId}/{groupId}")]
        public ActionResult GetByUserAndGroupId(int userId, int groupId)
        {
            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.GetByUserAndGroupId(userId, groupId));
            });
        }

        [HttpPut]
        public ActionResult Create(UserTradeHistoryModel userTradeHistoryModel)
        {
            return this.Run(() =>
            {
                return Ok(userTradeHistoryAppService.Create(userTradeHistoryModel));
            });
        }
    }
}
