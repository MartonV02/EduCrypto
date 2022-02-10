import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { BackendUrlEnum } from '../../../shared/BackendUrlEnum.constant';
import { GenericUrlGenerator } from '../../../shared/GenericUrlGenerator.service';
import { QuizModel } from '../model/quiz.model';
@Injectable({
  providedIn: 'root'
})

export class QuizService
{
    
    private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.Quiz);

  constructor(private http: HttpClient) { }

  public getQuiz(id:number): Observable<QuizModel>
  {
    var HttpURI = this._uriGenerator.GetUrlWithParam(id);
    return this.http.get<QuizModel>(HttpURI);  
  }

  public sendAnswer(answerId: number, userId: number): Observable<QuizModel>
  {
    var HttpURI = this._uriGenerator.GetUrlWithParam(answerId);
    return this.http.put<QuizModel>(HttpURI + '?userId=' + userId, answerId);
  }

}