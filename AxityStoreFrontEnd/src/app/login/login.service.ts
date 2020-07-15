import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { ILogin } from './login';
import { IUser } from './user';
import { APISERVER } from './../endpoint.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private loginUrl = '/api/User';

  constructor(private http: HttpClient) { }

  loginUser(login: ILogin): Observable<IUser> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<IUser>(`${APISERVER}${this.loginUrl}/Login`, login, { headers })
        .pipe(
            tap(data => console.log(JSON.stringify(data))),
            catchError(this.handleError)
        );
  }

  private handleError(err): Observable<never> {
    let errorMessage: string;

    switch (err.status)
    {
        case 404:
            errorMessage = 'No se encontro al usuario con estos datos';
            break;
        case 500:
            errorMessage = 'Ocurrio un problema en el servidor';
            break;
        default:
            errorMessage = 'Ocurrio un problema en la conexión';;
    }        
    return throwError(errorMessage);
  }
}
