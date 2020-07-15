import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { IProduct } from './product';
import { APISERVER } from './../endpoint.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productUrl = '/api/Product';

  constructor(private httpClient: HttpClient) {}

  getAllProducts(): Observable<IProduct[]>{
      return this.httpClient.get<IProduct[]>(`${APISERVER}${this.productUrl}`)
          .pipe(
              tap(data => console.log(JSON.stringify(data))),
              catchError(this.handleError)
          );
  }

  private handleError(err): Observable<never> {
      let errorMessage: string;
      
      switch (err.status)
      {
          case 500:
              errorMessage = 'Ocurrio un problema en el servidor';
              break;
          default:
              errorMessage = 'Ocurrio con la conexión';
      }

      return throwError(errorMessage);
  }
}
