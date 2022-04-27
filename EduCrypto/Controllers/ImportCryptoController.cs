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
        public ActionResult GetAll()
        {
            return this.Run(() =>
            {
                var result = CryptoData.Check();
                return Ok(result);
            });
        }

        [HttpGet("{cryptoSymbol}")]
        public ActionResult GetBySymbol(string cryptoSymbol)
        {
            return this.Run(() =>
            {
                return Ok(CryptoData.GetByCryptoSymbol(cryptoSymbol));
            });
        }
    }
}
