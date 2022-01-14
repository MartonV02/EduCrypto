using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz
{
    public class QuizModel
    {
        public string question{ get; set; }
        public string[] answers { get; set; }
        private int correctAnswer { get; set; }

        public QuizModel(string row)
        {
            string[] s = row.Split(';');
            this.question = s[0];
            for (int i = 0; i < 4; i++)
            {
                this.answers[i] = s[i + 1];
            }
            this.correctAnswer = int.Parse(s[4]);
        }

        public bool IsRight(int answer)
        {
            if (answer == this.correctAnswer)
            {
                return true;
            }
            return false;
        }
    }
}
