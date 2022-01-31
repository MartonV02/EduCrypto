import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { delay } from 'rxjs/operators';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';


@Component({
  selector: 'app-menu-sidebar-template',
  templateUrl: './menu-sidebar-template.component.html',
  styleUrls: ['./menu-sidebar-template.component.scss']
})
export class MenuSideBarTemplateComponent {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  @Output()
  readonly modeSwitched = new EventEmitter<boolean>();

  constructor(private observer: BreakpointObserver) { }

  ngAfterViewInit() {
    this.observer
      .observe(['(max-width: 800px)'])
      .pipe(delay(1))
      .subscribe((res) => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          this.sidenav.close();
        } else {
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }
      });
  }

  darkModeChange({ checked }: MatSlideToggleChange) {
    this.modeSwitched.emit(checked);
  }

}
