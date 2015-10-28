import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class PeopleDataHandler
{
    constructor(httpClient) {
        this.http = httpClient;
        http.configure(config => {
            config
                .useStandardConfiguration()
                .withBaseUrl('/api/people');
        });
    }

    getall() {
        return this.http.get()
            .then(response => response.content);
    }
}