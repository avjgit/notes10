import { Component } from '@angular/core';
import { HeroService } from './hero.service';
import { HeroesComponent } from './heroes.component';

@Component({
    selector: 'my-app',
    directives: [HeroesComponent],
    providers: [HeroService]
    template: `
<h1>{{title}}</h1>
<my-heroes></my-heroes>
`
})
export class AppComponent {
    title = 'Tour';
}