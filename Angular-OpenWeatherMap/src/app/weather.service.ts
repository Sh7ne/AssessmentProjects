import { Injectable } from '@angular/core';
import { CurrentWeather } from './current-weather';
import { Response, Http } from '@angular/http';
import 'rxjs/Rx';
import { promise } from 'protractor';

@Injectable()
export class WeatherService {
  myWeather: CurrentWeather;
  location 
  constructor(private http: Http) { }

  localWeather(){
   return new Promise ((res,rej)=> {
    navigator.geolocation.getCurrentPosition((pos)=>{
     this.location =pos.coords;
     const lat = this.location.latitude;
     const lon = this.location.longitude;
     return this.http.get('http://api.openweathermap.org/data/2.5/weather?appid=d0ee2549d313f1e2a8523d01fed2bf9f&units=metric&lat='+lat+'&lon='+lon).map((response: Response) => response.json()).toPromise().then(
       (data) =>{
         console.log(data);
        this.myWeather = new CurrentWeather(data.name,
                                            data.main.temp,
                                            data.weather[0].icon,
                                            data.weather[0].description,
                                            data.main.temp_max, 
                                            data.main.temp_min);
          res(this.myWeather);
       }
     );
    })
   })
  }

  cityWeather(city: string){
    return this.http.get('http://api.openweathermap.org/data/2.5/weather?appid=d0ee2549d313f1e2a8523d01fed2bf9f&units=metric&q='+city).map((response:Response)=> response.json());
  }

  fiveDayForeCast(city: string){
    return this.http.get('http://api.openweathermap.org/data/2.5/forecast?appid=d0ee2549d313f1e2a8523d01fed2bf9f&units=metric&q='+city).map((response: Response)=> response.json());
  }

}
