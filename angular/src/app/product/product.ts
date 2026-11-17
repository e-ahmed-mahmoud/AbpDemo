import { Component, input, OnInit, signal } from '@angular/core';
import { GetProductListDto, ProductDto, ProductService } from '../proxy/products';
import { PagedAndSortedResultRequestDto } from '@abp/ng.core';

@Component({
  selector: 'app-product',
  imports: [],
  templateUrl: './product.html',
  styleUrl: './product.scss',
  standalone: true,
})
export class Product implements OnInit {
  products = signal<ProductDto[]>([]);
  pagedList = signal<GetProductListDto>({
    maxResultCount: 1000,
    skipCount: undefined,
    sorting: '',
  });

  constructor(private productService: ProductService) {}
  ngOnInit(): void {
    this.productService.get(this.pagedList()).subscribe({
      complete: () => console.log('completed'),

      next: val => {
        console.log(val);
        this.products.set(val.items ?? []);
        this.pagedList.set({ skipCount: 0, maxResultCount: val.totalCount || 0 });
        console.log(this.products());
      },

      error: err => console.log(err),
    });
  }
}
