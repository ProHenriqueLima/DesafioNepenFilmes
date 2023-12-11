import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/login/login.component';
import { LoginService } from './app.component.service';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let component: AppComponent;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AppComponent, LoginComponent],
      imports: [
        MatButtonModule,
        MatIconModule,
        MatToolbarModule,
        MatGridListModule,
        MatSnackBarModule,
        HttpClientModule,
        RouterTestingModule,
      ],
      providers: [LoginService],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize correctly', () => {
    expect(component.title).toEqual('NepenFilmes');
    expect(component.situacaoLogin).toEqual('');
    expect(component.nomeUsuario).toBeUndefined();
    expect(component.cadastroOuLogin).toEqual('Login');
    expect(component.resultadoAutenticacao).toBeUndefined();
  });

  // Add more test cases based on your component logic
});
