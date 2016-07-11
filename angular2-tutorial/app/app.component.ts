import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
<h1>My second Angular 2 App, {{title}}</h1>
<span>Counter:{{count}}</span>
<button (click)="countClicks()">Click me</button>
`
})
export class AppComponent {
    title = "the app"; 
    count = 0;

    countClicks(){
        this.count++;
    }

}
