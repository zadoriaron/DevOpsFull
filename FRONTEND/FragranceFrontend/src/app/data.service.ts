import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap} from 'rxjs';
import { Fragrance } from './fragrance';
import { environment } from '../environments/environment.development';
import { Createfragrance } from './createfragrance';
import { Config } from './config';
import { ConfigService } from './config.service';



@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http:HttpClient, private config:ConfigService) { }

  private _perfumes:BehaviorSubject<Fragrance[]> = new BehaviorSubject<Fragrance[]>([])
  public perfumes = this._perfumes.asObservable()

  getDatas() {
    const url = `${this.config.cfg.backendUrl}/Fragrance/GetFragrances`;

    this.http.get<Fragrance[]>(url).subscribe(res => {
      this._perfumes.next(res);
    });
  }

  createFragrance(newfrag: Createfragrance): Observable<Fragrance> {

    const url = `${this.config.cfg.backendUrl}/Fragrance/AddFragrance`;

    return this.http.post<Fragrance>(url, newfrag).pipe(
      tap((frag: Fragrance) => {
        const current = this._perfumes.value;
        this._perfumes.next([...current, frag]);
      })
    );
  }

}
