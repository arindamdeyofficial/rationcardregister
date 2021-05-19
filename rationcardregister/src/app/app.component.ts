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
  userPic= "assets/img/userPic.png";  
  username = "Jayanta Ghosh";

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher
    , iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
      iconRegistry  
        .addSvgIcon(
          'search',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/search_black_24dp.svg')) 
        .addSvgIcon(
          'help',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/help_black_24dp.svg'))  
        .addSvgIcon(
          'admin',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/admin_panel_settings_black_24dp.svg'))
        .addSvgIcon(
          'login',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/login_black_24dp.svg'))
        .addSvgIcon(
          'logout',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/logout_black_24dp.svg'))  
        .addSvgIcon(
          'verifieduser',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/verified_user_black_24dp.svg'))
        .addSvgIcon(
          'print',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/print_black_24dp.svg')) 
        .addSvgIcon(
          'profile',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/account_box_black_24dp.svg')) 
        .addSvgIcon(
          'delete',
          sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/delete_black_24dp.svg'))    
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
