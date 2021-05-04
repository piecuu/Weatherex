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
  isLoading: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tokenStorageService: TokenStorageService,
    private weatherService: WeatherService
  ) {
    this.isLoading = true;
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    this.checkToken();
  }

  ngOnInit(): void {
  }

  checkToken(): void {
    const isAuthenticated = this.tokenStorageService.isAuthenticated();

    console.log(isAuthenticated);

    if (!isAuthenticated) {
      this.router.navigate([this.returnUrl]);
    }
    else {
      this.initializeData();
    }
  }

  initializeData(): void {
    this.weatherService.getWeatherForecast('Belfast').subscribe(data => {
      this.weatherResponse = data;
    },
    err => {
      console.log(err.error);
    });

    this.isLoading = false;
  }

}
