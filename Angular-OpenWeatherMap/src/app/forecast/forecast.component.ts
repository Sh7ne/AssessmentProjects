import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { Forecast } from '../forecast';
import { WeatherService } from '../weather.service';
import { ArrayType } from '@angular/compiler/src/output/output_ast';
import { element } from 'protractor';
import 'bootstrap';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent implements OnInit {

  constructor(private weatherService: WeatherService) { }

  forecastForm: FormGroup;
  cityForecast: Forecast[]=[];

  ngOnInit() {
    this.forecastForm = new FormGroup({
      forecastCity: new FormControl('')
    })
  }

  onSubmit(){
    this.cityForecast.splice(0,this.cityForecast.length)
    console.log(this.forecastForm);
    this.weatherService.fiveDayForeCast(this.forecastForm.value.forecastCity).subscribe(
      (data) =>{
        console.log(data);
        for(let i = 0; i<data.list.length; i+=8){
          const temporary = new Forecast(
            data.city.name,
            data.list[i].dt_txt,
            data.list[i].weather[0].icon,
            data.list[i].main.temp,
            data.list[i].main.pressure
          )

          this.cityForecast.push(temporary);
        }
        console.log(this.cityForecast);
        return this.cityForecast;
      }
    )
  }

}
