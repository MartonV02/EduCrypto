using Application.Common;
using Application.UserCrypto;
using Microsoft.AspNetCore.Mvc;
using EntityClass = Application.UserCrypto.UserCryptoModel;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCryptoController : ControllerBase
    {
        private readonly UserCryptoAppService _userCryptoAppService;
        public UserCryptoController(ApplicationDbContext dbContext)
        {
            this._userCryptoAppService = new UserCryptoAppService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userCryptoAppService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _userCryptoAppService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromQuery] EntityClass entity)
        {
            var result = _userCryptoAppService.Create(entity);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromQuery] EntityClass entity)
        {
            var result = _userCryptoAppService.Update(entity);

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            _userCryptoAppService.Delete(id);

            return Ok();
        }
    }
}
