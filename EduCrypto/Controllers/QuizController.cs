using Application.Common;
using Application.Quiz;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{xp}")]
        public ActionResult GetNextQuestion(int xp) //TODO should change userId
        {
            return this.Run(() =>
            {
                return Ok(quizAppService.GetQuestion(xp));
            });
        }

        [HttpPut("{xp}/{answer}")]
        public ActionResult CheckQuestion(int xp, int answer, int userId)
        {
            return this.Run(() =>
            {
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
