using Application.Common;
using Application.UserCrypto;
using Microsoft.AspNetCore.Mvc;
using EntityClass = Application.UserCrypto.UserCryptoModel;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCryptoController : Controller
    {
        private readonly UserCryptoAppService userCryptoAppService;
        public UserCryptoController(ApplicationDbContext dbContext)
        {
            this.userCryptoAppService = new UserCryptoAppService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Run(() =>
            {
                var result = userCryptoAppService.GetAll();

                return Ok(result);
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return this.Run(() =>
            {
                var result = userCryptoAppService.GetById(id);

                return Ok(result);
            });
        }

        [HttpGet("userForGroup/{userForGroupId:int}")]
        public IActionResult GetByUserForGroupsId(int userForGroupId)
        {
            return this.Run(() =>
            {
                var result = userCryptoAppService.GetByUserForGroupsId(userForGroupId);

                return Ok(result);
            });
        }

        [HttpGet("group/{groupId:int}")]
        public IActionResult GetByGroupId(int groupId)
        {
            return this.Run(() =>
            {
                var result = userCryptoAppService.GetByGroupId(groupId);

                return Ok(result);
            });
        }

        [HttpGet("Group/{groupId}/User/{userId}")]
        public IActionResult GetByGroupAndUserId(int groupId, int userId)
        {
            return this.Run(() =>
            {
                var result = userCryptoAppService.GetByGroupAndUserId(groupId, userId);

                return Ok(result);
            });
        }
    }
}
