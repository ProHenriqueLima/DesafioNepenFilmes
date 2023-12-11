import { ComponentFixture, TestBed, tick, fakeAsync } from '@angular/core/testing';
import { LoginComponent } from './login.component';
import { MatCardModule } from '@angular/material/card';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LoginService } from '../../app.component.service';
import { of, throwError } from 'rxjs';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let snackBar: MatSnackBar;
  let loginService: jasmine.SpyObj<LoginService>;

  beforeEach(() => {
    const loginServiceSpy = jasmine.createSpyObj('LoginService', ['efetuarLogin', 'efetuarCadastro']);

    TestBed.configureTestingModule({
      declarations: [LoginComponent],
      imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatSnackBarModule,
        HttpClientModule,
        FormsModule,
      ],
      providers: [{ provide: MatSnackBar, useValue: { open: jasmine.createSpy() } }, { provide: LoginService, useValue: loginServiceSpy }],
    }).compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    snackBar = TestBed.inject(MatSnackBar);
    loginService = TestBed.inject(LoginService) as jasmine.SpyObj<LoginService>;
  });

  it('deve ser criado', () => {
    expect(component).toBeTruthy();
  });

  it('deve inicializar corretamente', () => {
    expect(component.cadastroOuLogin).toEqual('Login');
    expect(component.hidePassword).toBe(true);
    expect(component.error).toEqual('');
    expect(component.Username).toBeUndefined();
    expect(component.Senha).toBeUndefined();
    expect(component.Nome).toBeUndefined();
  });

  it('deve chamar efetuarLogin no clique do botão de login', fakeAsync(() => {
    loginService.efetuarLogin.and.returnValue(of({ token: 'fakeToken', adm: { nome: 'FakeUser' } }));

    component.Username = 'fakeUsername';
    component.Senha = 'fakePassword';
    component.efetuarLogin();

    tick();

    expect(loginService.efetuarLogin).toHaveBeenCalledOnceWith({ id: 0, username: 'fakeUsername', nome: 'string', password: 'fakePassword', ativo: 1, cargo: 'string' });
    expect(localStorage.getItem('Token')).toEqual('fakeToken');
    expect(localStorage.getItem('UsuarioNome')).toEqual('FakeUser');
    expect(component.inicializarApp.emit).toHaveBeenCalledOnceWith();
    expect(snackBar.open).toHaveBeenCalledWith('Conectado com sucesso', 'fechar');
  }));

  it('deve lidar com erro no efetuarLogin', fakeAsync(() => {
    loginService.efetuarLogin.and.returnValue(throwError({ error: { error: 'FakeError' } }));

    component.Username = 'fakeUsername';
    component.Senha = 'fakePassword';
    component.efetuarLogin();

    tick();

    expect(snackBar.open).toHaveBeenCalledWith('FakeError', 'fechar');
  }));

  it('deve chamar efetuarCadastro no clique do botão de registrar', fakeAsync(() => {
    loginService.efetuarCadastro.and.returnValue(of({ token: 'fakeToken', adm: { nome: 'FakeUser' } }));

    component.Username = 'fakeUsername';
    component.Senha = 'fakePassword';
    component.Nome = 'FakeName';
    component.efetuarCadastro();

    tick();

    expect(loginService.efetuarCadastro).toHaveBeenCalledOnceWith({ id: 0, username: 'fakeUsername', nome: 'FakeName', password: 'fakePassword', ativo: 1, cargo: 'usuario' });
    expect(snackBar.open).toHaveBeenCalledWith('Cadastrado com sucesso, efetue o login.', 'fechar');
  }));

  it('deve lidar com erro no efetuarCadastro', fakeAsync(() => {
    loginService.efetuarCadastro.and.returnValue(throwError({ error: { error: 'FakeError' } }));

    component.Username = 'fakeUsername';
    component.Senha = 'fakePassword';
    component.Nome = 'FakeName';
    component.efetuarCadastro();

    tick();

    expect(snackBar.open).toHaveBeenCalledWith('FakeError', 'fechar');
  }));
});
