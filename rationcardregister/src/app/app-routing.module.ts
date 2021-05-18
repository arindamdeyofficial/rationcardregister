import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PagenotFoundComponent } from './pagenot-found/pagenot-found.component';
import { AboutAppComponent } from './about-app/about-app.component';
import { CustomerInputComponent } from './customer-input/customer-input.component';
import { CustomerSearchComponent } from './customer-search/customer-search.component';
import { HelpComponent } from './help/help.component';

const routes: Routes = [
  { path: '', component: CustomerInputComponent },   
  { path: 'customer', component: CustomerInputComponent },
  { path: 'search', component: CustomerSearchComponent },
  { path: 'about', component: AboutAppComponent },
  { path: 'help', component: HelpComponent },
  { path: '**', component: PagenotFoundComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
      { enableTracing: false, relativeLinkResolution: 'legacy' } // <-- debugging purposes only
 // <-- debugging purposes only
    )
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
