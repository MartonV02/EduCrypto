import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { QuizModel } from './model/quiz.model';
import { QuizService } from './service/quiz.service';
@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {

  
  public quizModel: QuizModel;
  public progressValue = 0;
  public userId = 2;
  public answer = 1;
  public isRight = true;
  constructor(public quizService: QuizService) { }

  ngOnInit(): void {
    this.getQuestion();
  }


  public getQuestion()
  {
    this.quizService.getQuiz(this.userId)
    .subscribe(result=> 
      {
        this.quizModel = result;
        console.log(this.quizModel);
      }
    )
  }


  public checkAnswer()
  {
    this.quizService.sendAnswer(this.answer, this.userId)
    .subscribe( result => 
      {
        this.isRight = result.isRight;
        console.log(result)
      });


      if (this.isRight)
      {
        
      }
  }

  

  


}
