import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ISearchResponse } from 'src/app/shared/models/searchResponse';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  find(searchTerm: string) {
    const params = new HttpParams().set('query', searchTerm);

    return this.http.get<ISearchResponse[]>(this.apiUrl + 'api/Search/', {
      params,
    });
  }
}
