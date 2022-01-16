using Application.Common;
using Application.CryptoCurrencies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoCurrencyController : Controller
    {
        readonly CryptoCurrencyAppService cryptoCurrencyAppService;

        public CryptoCurrencyController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            cryptoCurrencyAppService = new CryptoCurrencyAppService();
        }

        [HttpGet]
        public IEnumerable<CryptoCurrencyModel> GetAll()
        {
            return cryptoCurrencyAppService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return this.Run(() =>
            {
                return Ok(cryptoCurrencyAppService.GetById(id));
            });
        }
    }
}
