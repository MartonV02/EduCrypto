using Application.Quiz;
using Xunit;

namespace UnitTest
{
    public class Quiz_Test
    {
        [Fact]
        public void GetQuestion()
        {
            QuizAppService quizService = new();

            QuizModel quiz = quizService.GetQuestion(0);

            Assert.Equal("Hova megy a sündisznó?", quiz.question);
            Assert.Equal("Sehova", quiz.answers[0]);
            Assert.Equal("Az idegeidre", quiz.answers[1]);
            Assert.Equal("Haza", quiz.answers[2]);
            Assert.Equal("Boltba", quiz.answers[3]);
        }

        [Fact]
        public void CheckAnswerRight1()
        {
            QuizAppService quizService = new();

            bool result = quizService.CheckQuestion(1, 0);

            Assert.True(result);
        }

        [Fact]
        public void CheckAnswerRight2()
        {
            QuizAppService quizService = new();

            bool result = quizService.CheckQuestion(2, 1);

            Assert.True(result);
        }

        [Fact]
        public void CheckAnswerFalse1()
        {
            QuizAppService quizService = new();

            bool result = quizService.CheckQuestion(2, 0);

            Assert.False(result);
        }

        [Fact]
        public void CheckAnswerFalse2()
        {
            QuizAppService quizService = new();

            bool result = quizService.CheckQuestion(1, 1);

            Assert.False(result);
        }
    }
}
