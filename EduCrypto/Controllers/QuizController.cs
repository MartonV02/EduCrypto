using Application.Common;
using Application.Quiz;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        QuizAppService quizAppService = new QuizAppService();
        readonly UserHandlingAppService userHandlingAppService = new UserHandlingAppService();

        public QuizController(ApplicationDbContext dbContext)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userHandlingAppService = new UserHandlingAppService(dbContext);
        }

        [HttpGet("{userId}")]
        public ActionResult GetNextQuestion(int userId) //TODO should change userId
        {
            return this.Run(() =>
            {
                int xp = userHandlingAppService.GetById(userId).xpLevel;
                return Ok(quizAppService.GetQuestion(xp));
            });
        }

        [HttpPut("{answer}")]
        public ActionResult CheckQuestion(int answer, int userId)
        {
            return this.Run(() =>
            {
                int xp = userHandlingAppService.GetById(userId).xpLevel;
                bool check = quizAppService.CheckQuestion(answer, xp);
                if (check)
                {
                    UserHandlingModel user = userHandlingAppService.GetById(userId);
                    user.xpLevel++;
                    userHandlingAppService.Update(user);
                }
                return Ok(check);
            });
        }

    }
}
