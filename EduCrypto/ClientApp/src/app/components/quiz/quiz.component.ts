import { HttpClient } from '@angular/common/http';
import {Component,OnInit,Input,OnChanges,ChangeDetectorRef,} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { QuizModel } from './model/quiz.model';
import { QuizService } from './service/quiz.service';
@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss'],
})
export class QuizComponent implements OnInit {
  public quizModel: QuizModel;
  public progressValue = 0;
  public userId = 1;
  public isRight: boolean;

  constructor(
    public quizService: QuizService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.getQuestion();
    this.quizService.Refreshrequired.subscribe((response) => {
      this.getQuestion();
    });
  }

  public getQuestion() {
    this.quizService.getQuiz(this.userId).subscribe((result) => {
      this.quizModel = result;
      console.log(this.quizModel);
    });
  }

  public checkAnswer(answerId: number) {
    this.quizService
      .sendAnswer(answerId, this.userId)
      .pipe()
      .subscribe((result) => {
        this.isRight = result.isRight;
        console.log(result);
        if (this.isRight) {
          this.progressValue += 20;
          this.cdr.detectChanges();
        }
        console.log(this.progressValue);
      });
  }
}
