import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HeroService } from './hero.service';
import { HeroFormComponent } from './hero-form.component';

@Component({
    selector: 'my-app',
    directives: [ROUTER_DIRECTIVES, HeroFormComponent],
    providers: [HeroService],
    styleUrls: ['app/app.component.css'],
    template: `

<h1>{{title}}</h1>

<nav>
    <a [routerLink]="['/dashboard']" routerLinkActive="active">
        Dashboard
    </a>

    <a [routerLink]="['/heroes']" routerLinkActive="active">
        Heroes
    </a>
</nav>

<router-outlet></router-outlet>
<hero-form></hero-form>
`
})
export class AppComponent {
    title = 'Tour';
}