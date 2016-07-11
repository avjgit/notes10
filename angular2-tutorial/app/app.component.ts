import { Component } from '@angular/core';

export class Hero {
    id: number;
    name: string;
}

@Component({
  selector: 'my-app',
  template: `
<span>Counter:{{count}}</span><button (click)="countClicks()">Click me</button>

<h1>{{title}}</h1>

<h2>{{hero.name}} details!</h2>
<div><label>id: </label>{{hero.id}}</div>
<div>
    <label>name: </label>
    <input value="{{hero.name}}" placeholder="name">    
</div>
`
})
export class AppComponent {
    count = 0;
    countClicks(){
        this.count++;
    }

    title = "Tour of Heroes"; 
    hero: Hero = {
        id: 1,
        name: 'Superman'
    }    

}
