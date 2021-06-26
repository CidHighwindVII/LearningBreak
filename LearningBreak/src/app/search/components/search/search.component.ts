import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ISearchResponse } from 'src/app/shared/models/searchResponse';
import { SearchService } from '../../services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent {
  @ViewChild('search', { static: false }) searchTerm: ElementRef;
  searchList: ISearchResponse[];

  constructor(private searchService: SearchService) {}

  onSearch(): void {
    this.searchService
      .find(this.searchTerm.nativeElement.value)
      .subscribe((res) => {
        this.searchList = res;
      });
  }
}
