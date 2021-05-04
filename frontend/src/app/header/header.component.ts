import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../core/services/token-storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn$: Observable<boolean>;

  constructor(
    private tokenStorageService: TokenStorageService
  ) { }

  ngOnInit(): void {
    this.isLoggedIn$ = this.tokenStorageService.isLoggedIn;
  }

  onLogout(): void {
    this.tokenStorageService.logout();
  }

}
