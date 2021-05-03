import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../core/services/auth-service.service';
import { TokenStorageService } from '../core/services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  isLogged = false;
  loginInvalid = false;
  errorResponse = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private tokenStorageService: TokenStorageService
  ) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const username = this.form.get('username')?.value;
    const password = this.form.get('password')?.value;

    this.authService.login(username, password).subscribe(data => {
      this.tokenStorageService.saveToken(data);
      this.isLogged = true;
    },
    err => {
      this.errorResponse = err.error;
      this.loginInvalid = true;
    });
  }
}
