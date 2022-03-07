import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { map, take, tap } from 'rxjs/operators';
import { BackendUrlEnum } from '../../../shared/BackendUrlEnum.constant';
import { GenericUrlGenerator } from '../../../shared/GenericUrlGenerator.service';
import { RegisterModel } from '../model/register.model';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(
    BackendUrlEnum.UserHandling
  );

  constructor(private http: HttpClient,) {}

  
  public createUser(user: RegisterModel): Observable<RegisterModel> {
    var HttpURI = this._uriGenerator.GetBasicUrl();
    return this.http.put<RegisterModel>(HttpURI, user);
  }
}
