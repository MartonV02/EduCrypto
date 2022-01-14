using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz
{
    public class QuizAppService
    {
        public List<QuizModel> Questions { get; set; }

        public QuizAppService()
        {
            Questions = new List<QuizModel>();
            StreamReader sr = new StreamReader("question.txt");
            while (!sr.EndOfStream)
            {
                Questions.Add( new QuizModel(sr.ReadLine()));
            }
        }

        public QuizModel GetQuestion(int  xp)
        {
            return Questions[xp];
        }

        public bool CheckQuestion(int answer, int xp)
        {
            return Questions[xp].IsRight(answer);
        }
    }
}
