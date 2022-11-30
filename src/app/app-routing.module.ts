import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LiderComponent } from './Components/lider/lider.component';
import { PlayComponent } from './Components/play/play.component';

const routes: Routes = [
  {path: 'play', component: PlayComponent},
  {path: '',  component: HomeComponent},
  {path: 'liders', component: LiderComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
