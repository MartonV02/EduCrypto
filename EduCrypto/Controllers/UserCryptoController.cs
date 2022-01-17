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
        private readonly UserCryptoAppService _userCryptoAppService;
        public UserCryptoController(ApplicationDbContext dbContext)
        {
            this._userCryptoAppService = new UserCryptoAppService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.GetAll();

                return Ok(result);
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.GetById(id);

                return Ok(result);
            });
        }

        [HttpGet("{userForGroupId:int}")]
        public IActionResult GetByUserForGroupsId(int userForGroupId)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.GetByUserForGroupsId(userForGroupId);

                return Ok(result);
            });
        }

        [HttpGet("{groupId:int}")]
        public IActionResult GetByGroupId(int groupId)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.GetByGroupId(groupId);

                return Ok(result);
            });
        }

        //Biztosan törölni kell ilyet nem lehet
        [HttpGet("Group/{groupId}/Crypto/{cryptoId}")]
        public IActionResult GetByGroupAndCryptoId(int groupId, int cryptoId)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.GetByGroupAndCryptoId(groupId, cryptoId);

                return Ok(result);
            });
        }

        //Group Controllerbe kell
        [HttpGet("Group/{groupId}/User/{userId}")]
        public IActionResult GetByGroupAndUserId(int groupId, int userId)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.GetByGroupAndUserId(groupId, userId);

                return Ok(result);
            });
        }

        [HttpPost]
        public IActionResult Create([FromQuery] EntityClass entity)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.Create(entity);

                return Ok(result);
            });
        }

        [HttpPut]
        public IActionResult Update([FromQuery] EntityClass entity)
        {
            return this.Run(() =>
            {
                var result = _userCryptoAppService.Update(entity);

                return Ok(entity);
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.Run(() =>
            {
                _userCryptoAppService.Delete(id);

                return Ok();
            });
        }
    }
}
