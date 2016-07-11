import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
<span>Counter:{{count}}</span><button (click)="countClicks()">Click me</button>

<h1>{{title}}</h1>
You'll learn about {{hero}}!
`
})
export class AppComponent {
    count = 0;
    countClicks(){
        this.count++;
    }

    title = "Tour of Heroes"; 
    hero = "Manbearpig";    

}
