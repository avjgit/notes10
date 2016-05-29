// Angular is modular.
// When something is needed, it is being imported
// Here Component is being taken from core
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
//Component is a decorator function that 
//takes a metadata object as argument. 
var core_1 = require('@angular/core');
//We apply this function to the component class 
//by prefixing the function with the @ symbol 
//and invoking it with a metadata object, 
//just above the class
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        core_1.Component({
            //a simple CSS selector for an HTML element 
            //that represents the component
            selector: 'my-app',
            // A component controls a portion of the screen 
            // — a view — through its associated template
            //how to render this component's view
            template: '<h1>My Second Angular 2 App</h1>'
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map