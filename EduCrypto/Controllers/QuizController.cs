using Application.Common;
using Application.Common.Auth;
using Application.Quiz;
using Application.UserHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace EduCrypto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly IConfiguration config;
        private readonly QuizAppService quizAppService = new();
        private readonly UserHandlingAppService userHandlingAppService = new();

        public QuizController(ApplicationDbContext dbContext, IConfiguration config)
        {
#if DEBUG
            dbContext.Database.EnsureCreated();
#endif
            userHandlingAppService = new UserHandlingAppService(dbContext);
            this.config = config;
        }

        [HttpGet("{userId}")]
        public ActionResult GetNextQuestion(int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.getUserIdFromToken(config, token) != userId)
                return Forbid();
            return this.Run(() =>
            {
                int xp = userHandlingAppService.GetById(userId).xpLevel;
                return Ok(quizAppService.GetQuestion(xp));
            });
        }

        [HttpPut("{answer}")]
        public ActionResult CheckQuestion(int answer, int userId)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (AuthenticationExtension.getUserIdFromToken(config, token) != userId)
                return Forbid();
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
