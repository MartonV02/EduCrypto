using Application.UserCrypto;
using Microsoft.AspNetCore.Mvc;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserCryptoController : Controller
    {
        private readonly UserCryptoAppService _userCryptoAppService;
        public UserCryptoController(UserCryptoAppService userCryptoAppService)
        {
            this._userCryptoAppService = userCryptoAppService;
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
        public IActionResult Create([FromQuery] UserCrypto entity)
        {
            var result = _userCryptoAppService.Create(entity);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromQuery] UserCrypto entity)
        {
            var result = _userCryptoAppService.Update(entity);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] UserCrypto entity)
        {
            var result = _userCryptoAppService.Delete(entity);

            return Ok();
        }
    }
}
