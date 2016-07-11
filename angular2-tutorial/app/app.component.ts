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

<h2>All heroes</h2>
<ul class="heroes">
    <li *ngFor="let hero of heroes">
        <span class="badge">{{hero.id}}</span> {{hero.name}}    
    </li>
</ul>


<h2>{{hero.name}} details!</h2>
<div><label>id: </label>{{hero.id}}</div>
<div>
    <label>name: </label>
    <input [(ngModel)]="hero.name" placeholder="name">    
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
    public heroes = HEROES;

}

const HEROES: Hero[] = [
  { id: 11, name: 'Mr. Nice' },
  { id: 12, name: 'Narco' },
  { id: 13, name: 'Bombasto' },
  { id: 14, name: 'Celeritas' },
  { id: 15, name: 'Magneta' },
  { id: 16, name: 'RubberMan' },
  { id: 17, name: 'Dynama' },
  { id: 18, name: 'Dr IQ' },
  { id: 19, name: 'Magma' },
  { id: 20, name: 'Tornado' }
];
