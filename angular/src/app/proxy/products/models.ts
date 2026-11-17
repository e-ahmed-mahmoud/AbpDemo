import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateProductDto extends EntityDto<string> {
  nameEn: string;
  nameAr: string;
  descripationEn: string;
  descripationAr: string;
  price?: number;
  categoryId?: number;
}

export interface GetProductListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface ProductDto extends FullAuditedEntityDto<string> {
  nameEn: string;
  nameAr: string;
  descripationEn: string;
  descripationAr: string;
  price?: number;
  categoryNameEn?: string;
  categoryNameAr?: string;
}
