import type { CreateUpdateProductDto, GetProductListDto, ProductDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  
  create = (createUpdateProductDto: CreateUpdateProductDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProductDto>({
      method: 'POST',
      headers: { Accept: 'application/json' },
      url: '/api/app/product',
      body: createUpdateProductDto,
    },
      { apiName: this.apiName,...config });
  

  
  delete = (productId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, boolean>({
      method: 'DELETE',
      headers: { Accept: 'application/json' },
      url: '/api/app/product',
      params: { productId },
    },
      { apiName: this.apiName,...config });
  

  
  get = (dto: GetProductListDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ProductDto>>({
      method: 'GET',
      headers: { Accept: 'application/json' },
      url: '/api/app/product',
      params: { filter: dto.filter, sorting: dto.sorting, skipCount: dto.skipCount, maxResultCount: dto.maxResultCount },
    },
      { apiName: this.apiName,...config });
  

  
  getById = (productId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProductDto>({
      method: 'GET',
      headers: { Accept: 'application/json' },
      url: `/api/app/product/by-id/${productId}`,
    },
      { apiName: this.apiName,...config });
  

  
  update = (createUpdateProductDto: CreateUpdateProductDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProductDto>({
      method: 'PUT',
      headers: { Accept: 'application/json' },
      url: '/api/app/product',
      body: createUpdateProductDto,
    },
      { apiName: this.apiName,...config });
}
