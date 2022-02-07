using Application.Common;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EduCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHandlingController : Controller
    {
        readonly UserHandlingAppService userHandlingAppService;

        public UserHandlingController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userHandlingAppService = new UserHandlingAppService(dbContext);
        }

        [HttpGet]
        public IEnumerable<UserHandlingModel> GetAll()
        {
            return userHandlingAppService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return this.Run(() =>
            {
                return Ok(userHandlingAppService.GetById(id));
            });
        }

        [HttpPut]
        public ActionResult Create(UserHandlingModel user)
        {
            return this.Run(() =>
            {
                return Ok(userHandlingAppService.Create(user));
            });
        }

        [HttpPost]
        public ActionResult Modify(UserHandlingModel user)
        {
            return this.Run(() =>
            {
                return Ok(userHandlingAppService.Update(user));
            });
        }

        [HttpDelete]
        public ActionResult Delete(UserHandlingModel user)
        {
            return this.Run(() =>
            {
                userHandlingAppService.Delete(user.Id);
                return Ok();
            });
        }

    }
}
