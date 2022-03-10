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
                UserHandlingModel result = userHandlingAppService.Create(user);
                return Ok(new
                {
                    result.Id,
                    result.userName,
                    result.email,
                    result.fullName,
                    result.birthDate,
                    result.moneyDollar,
                    result.xpLevel,
                });
            });
        }

        [HttpPost]
        public ActionResult Modify(UserHandlingModel user)
        {
            return this.Run(() =>
            {
                //TODO disable modifing some fields
                UserHandlingModel modified = userHandlingAppService.GetById(user.Id);
                modified.Id = user.Id;
                modified.userName = user.userName;
                modified.email = user.email;
                modified.fullName = user.fullName;
                modified.birthDate = user.birthDate;
                modified.Password = user.Password;
                UserHandlingModel result = userHandlingAppService.Update(modified);
                return Ok(new
                {
                    result.Id,
                    result.userName,
                    result.email,
                    result.fullName,
                    result.birthDate,
                    result.moneyDollar,
                    result.xpLevel,
                });
            });
        }

        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            return this.Run(() =>
            {
                userHandlingAppService.Delete(userId);
                return Ok("Succesfull delete");
            });
        }

    }
}
