import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  returnUrl: string;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private tokenStorageService: TokenStorageService
  ) {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    if (this.tokenStorageService.getToken()) {
      this.router.navigate([this.returnUrl]);
    }
  }

  onSubmit(): void {
    const username = this.form.get('username')?.value;
    const password = this.form.get('password')?.value;

    this.authService.login(username, password).subscribe(data => {
      this.tokenStorageService.saveToken(data);
      this.isLogged = true;
      this.router.navigate([this.returnUrl]);
    },
    err => {
      this.errorResponse = err.error;
      this.loginInvalid = true;
    });
  }
}
