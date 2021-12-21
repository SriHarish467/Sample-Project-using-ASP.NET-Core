import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private apiEndPoint= environment.apiEndPoint;
  constructor(private httpClient:HttpClient) { }

  public getRequest():Observable<any>{
    return this.httpClient.get(this.apiEndPoint);
  }
  public getRequestById(id:any):Observable<any>{
    return this.httpClient.get(this.apiEndPoint+id);
  }
  public create(data:any):Observable<any>{
   return this.httpClient.post(this.apiEndPoint,data);
  }
  public update(data:any):Observable<any>{
    return this.httpClient.put(this.apiEndPoint,data);
  }
  public delete(id:any):Observable<any>{
    return this.httpClient.delete(this.apiEndPoint+id)
  }
}
