import { NumberInput } from '@angular/cdk/coercion';
import { HttpClient } from '@angular/common/http';
import {Component,OnInit,Input,OnChanges,ChangeDetectorRef,} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { LoginService } from '../login/service/login.service';
import { QuizModel } from './model/quiz.model';
import { QuizService } from './service/quiz.service';
import {MatSnackBar} from '@angular/material/snack-bar';
@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss'],
})
export class QuizComponent implements OnInit {
  public quizModel: QuizModel;
  public progressValue = 0;
  private userId:number;
  public answers: string[];
  public badRequest:boolean;

  constructor(
    public quizService: QuizService,
    private cdr: ChangeDetectorRef,
    private login: LoginService,
    private snack: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.userId = this.login.provideActualUserId;
    this.getQuestion();
    this.quizService.Refreshrequired.subscribe((response) => {
      this.getQuestion();
    });
  }

  public getQuestion() {
    this.quizService.getQuiz(this.userId).subscribe(
      (result) => {
      this.quizModel = result;
      this.answers = this.quizModel.answers;},
      (error) => {
        if (error.status == 400)
        this.badRequest = true;
      }
    );
  }

  public checkAnswer(answerId: number) {
    this.quizService
      .sendAnswer(answerId, this.userId)
      .pipe()
      .subscribe((result) => {
        if (result) {
          this.snack.open('Correct', 'Okay',{
            duration: 2000});
        }
        else
        {
          this.snack.open('Wrong answer', 'Okay',{
            duration: 2000});
        }
      });
  }

}
