import { Component, OnInit, signal } from '@angular/core';
import { CategoryDto, CategoryService } from '../proxy/categories';
import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { DataTableColumnDirective, DatatableComponent } from '@swimlane/ngx-datatable';

@Component({
  selector: 'app-category',
  imports: [DatatableComponent, DataTableColumnDirective],
  templateUrl: './category.html',
  styleUrl: './category.scss',
})
export class Category implements OnInit {
  categories = signal<CategoryDto[]>([]);
  pagedList = signal<PagedAndSortedResultRequestDto>({ maxResultCount: 1000 });

  constructor(private categoryService: CategoryService) {}
  ngOnInit(): void {
    this.categoryService.getList(this.pagedList()).subscribe({
      next: val => {
        this.categories.set(val.items ?? []);
        this.pagedList.set({
          maxResultCount: val.totalCount || 0,
          skipCount: 0,
          sorting: '',
        });
      },
      error: err => console.log(err),
    });
  }
}
