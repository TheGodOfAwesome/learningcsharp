import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class ToDoService {
    public url: string = 'http://localhost:50519/api/todo/';

    constructor(private httpClient: HttpClient) {}

    getAll(): Observable<any> {
        return this.httpClient.get(this.url);
    }

    getOne(value: any) {
        return this.httpClient.get(this.url + "{" + value + "}");
    }

    addOne(value: any) {
        return this.httpClient.post(this.url, value);
    }

    updateOne(value: any) {
        return this.httpClient.put(this.url, value);
    }

    deleteOne(value: any) {
        return this.httpClient.delete(this.url, value);
    }
}