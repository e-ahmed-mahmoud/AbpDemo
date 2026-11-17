import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CategoryDto extends AuditedEntityDto {
  nameEn: string;
  nameAr: string;
}

export interface CreateUpdateCategoryDto extends EntityDto<number> {
  nameEn: string;
  nameAr: string;
}
