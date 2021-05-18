import {MediaMatcher} from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import {DomSanitizer} from '@angular/platform-browser';
import {MatIconRegistry} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu'
import {MatListModule} from '@angular/material/list';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'rationcardregister';
  mobileQuery: MediaQueryList;
  comingsoonPicPath = "assets//images/comingsoon.png";
  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher
    , iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
      iconRegistry
        .addSvgIcon(
          'input',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/assignment_black_24dp.svg'))  
        .addSvgIcon(
          'search',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/search_black_24dp.svg')) 
        .addSvgIcon(
          'help',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/help_black_24dp.svg'))       
            ;
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

    ngOnDestroy(): void {
      this.mobileQuery.removeListener(this._mobileQueryListener);
    }
    onOpenMenu(menu: any): void {
      console.log(menu);
    }
}
