using Microsoft.AspNetCore.Mvc;
using Application.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserHandling;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        QuizAppService quizAppService = new QuizAppService();
        UserHandlingAppService userHandlingAppService = new UserHandlingAppService();

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
                    UserHandling user = userHandlingAppService.GetById(userId);
                    user.xpLevel++;
                    userHandlingAppService.Update(user);
                }
                return Ok(check);
            });
        }

    }
}
