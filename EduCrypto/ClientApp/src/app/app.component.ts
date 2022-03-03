import { DOCUMENT } from '@angular/common';
import { Component, Inject, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2
  ) {}

  public isDarkRecaptcha: boolean;

  switchMode(isDarkMode: boolean) {
    const baseClass = isDarkMode ? 'theme-dark' : 'theme-light';
    this.renderer.setAttribute(this.document.body, 'class', baseClass);
    if (isDarkMode) {
      this.isDarkRecaptcha = true;
    } else {
      this.isDarkRecaptcha = false;
    }
  }
}
