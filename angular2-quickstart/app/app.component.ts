// Angular is modular.
// When something is needed, it is being imported
// Here Component is being taken from core

//Component is a decorator function that 
//takes a metadata object as argument. 
import { Component } from '@angular/core';

//We apply this function to the component class 
//by prefixing the function with the @ symbol 
//and invoking it with a metadata object, 
//just above the class
@Component({
    //a simple CSS selector for an HTML element 
    //that represents the component
    selector: 'my-app',
    // A component controls a portion of the screen 
    // — a view — through its associated template
    //how to render this component's view
    template: '<h1>My Second Angular 2 App</h1>'
})

// Every Angular app has 
// at least (??) one root component, 
// conventionally named AppComponent.
//We export AppComponent so that we can import it 
//elsewhere in our application, 
//as we'll see when we create main.ts
export class AppComponent {}