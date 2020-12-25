import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AlunosComponent } from './components/alunos/alunos.component';
import { AlunosProfessoresComponent } from './components/alunos/alunos-professores/alunos-professores.component';
import { ProfessoresComponent } from './components/professores/professores.component';
import { ProfessorDetalheComponent } from './components/professores/professor-detalhe/professor-detalhe.component';
import { ProfessoresAlunosComponent } from './components/professores/professores-alunos/professores-alunos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { TituloComponent } from './components/shared/titulo/titulo.component';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    ProfessoresComponent,
    AlunosProfessoresComponent,
    ProfessorDetalheComponent,
    ProfessoresAlunosComponent,
    PerfilComponent,
    DashboardComponent,
    NavComponent,
    TituloComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    HttpClientModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
