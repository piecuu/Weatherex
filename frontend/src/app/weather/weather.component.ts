import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TokenStorageService } from '../core/services/token-storage.service';
import { WeatherService } from '../core/services/weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  returnUrl = '';
  weatherResponse: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tokenStorageService: TokenStorageService,
    private weatherService: WeatherService
  ) {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    this.initializeData();
  }

  ngOnInit(): void {
  }

  initializeData(): void {
    this.weatherService.getWeatherForecast('Belfast').subscribe(data => {
      this.weatherResponse = data;
      console.log(this.weatherResponse);
    },
    err => {
      console.log(err.error);
    });
  }

}
