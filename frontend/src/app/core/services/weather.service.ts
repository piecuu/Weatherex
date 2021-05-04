import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  private readonly apiUrl = `${environment.apiUrl}api/weather/`;

  constructor(private http: HttpClient) { }

  getWeatherForecast(location: string): Observable<any> {
    return this.http.get(this.apiUrl + location);
  }
}
