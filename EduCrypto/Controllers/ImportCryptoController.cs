using Application.Common;
using Application.ImportCryptos;
using Microsoft.AspNetCore.Mvc;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportCryptoController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Run(() =>
            {
                var result = CryptoData.Check();
                return Ok(result);
            });
        }
    }
}
