import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap} from 'rxjs';
import { Fragrance } from './fragrance';
import { environment } from '../environments/environment.development';
import { Createfragrance } from './createfragrance';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http:HttpClient) { }

  private _perfumes:BehaviorSubject<Fragrance[]> = new BehaviorSubject<Fragrance[]>([])
  public perfumes = this._perfumes.asObservable()

  getDatas()
  {
    this.http.get<Fragrance[]>(environment.apis.get).subscribe(res => {
      this._perfumes.next(res)
    })
  }

  createFragrance(newfrag:Createfragrance):Observable<Fragrance>
  {
    return this.http.post<Fragrance>(environment.apis.create, newfrag).pipe(

      tap((newfrag:Fragrance) => {
        const current = this._perfumes.value
        this._perfumes.next([...current, newfrag])
      })
    )
  }

}
