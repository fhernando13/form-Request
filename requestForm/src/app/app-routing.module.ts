import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RequestFormComponent } from './component/request-form/request-form.component';
import { RequestListComponent } from './component/request-list/request-list.component';
import { ListStateComponent } from './component/list-state/list-state.component';

const routes: Routes = [
  { path: '', redirectTo: '/requestForm', pathMatch: 'full' },
  { path: 'requestForm', component: RequestFormComponent },
  { path: 'requestList', component: RequestListComponent },//
  { path: 'listStates', component: ListStateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
