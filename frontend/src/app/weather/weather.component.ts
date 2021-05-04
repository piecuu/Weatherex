import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
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
  isLoading: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tokenStorageService: TokenStorageService,
    private weatherService: WeatherService
  ) {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    this.checkToken();
  }

  ngOnInit(): void {
  }

  checkToken(): void {
    const isAuthenticated = this.tokenStorageService.isAuthenticated();

    if (!isAuthenticated) {
      this.router.navigate([this.returnUrl]);
    }
    else {
      this.getWeatherData();
    }
  }

  getWeatherData(): void {
    this.weatherResponse = null;

    this.weatherService.getWeatherForecast('Belfast').subscribe(data => {
      this.weatherResponse = data;
    },
    err => {
    });

  }
}
