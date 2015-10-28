import {inject} from 'aurelia-framework';import {inject} from 'aurelia-framework';
import {PeopleDataHandler} from "/DataHandlers/PeopleDataHandler";

@inject(PeopleDataHandler)
export class App {
    heading = 'People';
    people = [];

    constructor(pdh) {
        this.pdh = pdh;
    }

    activate() {
        return this.pdh.getAll().then(people => this.people = people);
    }
}