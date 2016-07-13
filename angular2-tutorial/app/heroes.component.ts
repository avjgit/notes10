import { Component } from '@angular/core';
import { Hero } from './hero';
import { HeroDetailComponent } from './hero-detail.component';
import { HeroService } from './hero.service';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
    styleUrls: ['app/heroes.component.css'],
    selector: 'my-heroes',
    templateUrl: 'app/heroes.component.html',
  directives: [HeroDetailComponent],
  providers: []
})
export class HeroesComponent implements OnInit{

    hero: Hero = {
        id: 1,
        name: 'Mr.ClassMan'
    };

    heroes: Hero[];

    selectedHero: Hero;

    onSelect(hero: Hero){
        this.selectedHero = hero;
    }

    constructor(
      private heroService: HeroService,
      private router: Router) {
    }

    getHeroes() {
      this.heroService.getHeroes().then(
        heroes => this.heroes = heroes
      )
    };

    ngOnInit(){
      this.getHeroes();
    }

    gotoDetail() {
      this.router.navigate(['/detail', this.selectedHero.id]);
    }
}