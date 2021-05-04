import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

const TOKEN_KEY = 'token';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor() { }

  public saveToken(token: string): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }

  public isAuthenticated(): boolean {
    const helper = new JwtHelperService();

    const token = this.getToken();

    if (token) {
      const isExpired = helper.isTokenExpired(token);

      if (isExpired) {
        return false;
      }

      return true;
    }
    else {
      return false;
    }
  }

  public logout(): void {
    localStorage.clear();
  }
}
