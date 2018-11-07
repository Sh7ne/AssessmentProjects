import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { WeatherService } from '../weather.service';
import { CurrentWeather } from '../current-weather';
import 'rxjs/Rx';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-current',
  templateUrl: './current.component.html',
  styleUrls: ['./current.component.css']
})
export class CurrentComponent implements OnInit {
  myWeather: CurrentWeather;
  
  constructor(private ws: WeatherService, private route:ActivatedRoute) { }
  
  ngOnInit() {
    this.route.data.subscribe(
      (data:{myWeather: CurrentWeather})=>{
        this.myWeather = data.myWeather;
      }
    )
  }
  onSubmit(weatherForm: NgForm){
    console.log(weatherForm);
    this.ws.cityWeather(weatherForm.value.city).subscribe((data) =>{
     console.log(data);
     this.myWeather = new CurrentWeather(data.name,
                                         data.main.temp,
                                         data.weather[0].icon,
                                         data.weather[0].description,
                                         data.main.temp_max, 
                                         data.main.temp_min);
    })
  }

}
