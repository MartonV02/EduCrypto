using Application.Common;
using Application.CryptoCurrencies;
using Application.UserCrypto;
using Application.UserForGroups;
using Application.UserHandling;
using Application.UserTradeHistory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTradeHistoryController : Controller
    {
        readonly UserTradeHistoryAppService userTradeHistoryAppService;
        readonly UserHandlingAppService userHandlingAppService;
        readonly UserForGroupsAppService userForGroupsAppService;
        readonly UserCryptoAppService userCryptoAppService;
        readonly CryptoCurrencyAppService cryptoCurrencyAppService;

        public UserTradeHistoryController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userTradeHistoryAppService = new UserTradeHistoryAppService(dbContext);
            userHandlingAppService = new UserHandlingAppService(dbContext);
            userForGroupsAppService = new UserForGroupsAppService(dbContext);
            userCryptoAppService = new UserCryptoAppService(dbContext);
            cryptoCurrencyAppService = new CryptoCurrencyAppService(dbContext);
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
                return Ok(userTradeHistoryAppService.CreateWithTransaction(userTradeHistoryModel, this.userHandlingAppService, 
                    this.cryptoCurrencyAppService, this.userCryptoAppService, this.userForGroupsAppService));
            });
        }
    }
}
