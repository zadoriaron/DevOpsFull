import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Config } from './config';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor(private http:HttpClient) { }

  public cfg: Config = new Config()

  load()
  {
    return this.http.get<Config>('config.json',{headers:{'Cache-Control': 'no-cache'}}).pipe(
      tap(t => {
        this.cfg = t;
      })
    )
  }


}
