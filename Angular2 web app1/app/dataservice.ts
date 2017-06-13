import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

export class MyHttpService {

    constructor( @Inject(Http) private http: Http) { }

    headers = new Headers({
        'Content-Type': 'application/json'
    });

    postJson(url: string, data: any): Observable<Response> {
        return this.http.post(
            url,
            JSON.stringify(data),
            { headers: this.headers }
        )
    }

    getJson(url: string): Observable<any> {
        return this.http.get(url).map((response: Response) => response.json())
    }

    delete(url: string): Observable<any> {
        return this.http.delete(url).map((response: Response) => response.text());
    }

    putJson(url: string, data: any): Observable<any> {
        return this.http.put(
            url,
            JSON.stringify(data),
            { headers: this.headers }
        )
    }
}
