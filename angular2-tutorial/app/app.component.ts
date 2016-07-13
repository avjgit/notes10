import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HeroService } from './hero.service';

@Component({
    selector: 'my-app',
    directives: [ROUTER_DIRECTIVES],
    providers: [HeroService],
    template: `
<h1>{{title}}</h1>
<a [routerLink]="['/heroes']">Heroes</a>
<router-outlet></router-outlet>
`
})
export class AppComponent {
    title = 'Tour';
}