using Application.ImportCryptos;
using Microsoft.AspNetCore.Mvc;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportCryptoController : Controller
    {
        private ImportCryptosAppService _importCryptoAppService;
        public ImportCryptoController(ImportCryptosAppService importCryptoAppService)
        {
            this._importCryptoAppService = importCryptoAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this._importCryptoAppService.GetCryptoList();

            return Ok(result);
        }
    }
}
