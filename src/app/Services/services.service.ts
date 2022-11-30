import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Attempt } from '../models/attempt.model';
import { Gamer } from '../models/gamer.model';
import { Winner } from '../models/lider.model';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http : HttpClient) { }

  CreateUser(name?:string ) : Observable<Gamer>
  {
      return this.http.post<Gamer>("https://localhost:7043/api/Game/CreateGamer?name="+name,"");
  }

  PlayGame(number:string, userId:string):Observable<Array<Attempt>>
  {
    return this.http.post<Array<Attempt>>("https://localhost:7043/api/Game/Play?guessNumber="+number+"&userId="+userId,"")
  }



  GetLiders() : Observable<Array<Winner>>
  {
    return this.http.get<Array<Winner>>("https://localhost:7043/api/Game/GetLider")
  }
}
