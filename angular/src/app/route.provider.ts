import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';
export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];
function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
    {
      path: '/',
      name: '::Menu:Home',
      iconClass: 'fas fa-home',
      order: 1,
      layout: eLayoutType.application,
    },
    {
      path: '/products',
      name: 'products',
      iconClass: 'fa-solid fa-store',
      layout: eLayoutType.application,
      //requiredPolicy: 'AbpDemo.Books',
    },
    {
      path: '/category',
      name: 'categories',
      iconClass: 'fa-solid fa-cubes',
      layout: eLayoutType.application,
      //requiredPolicy: 'AbpDemo.Authors',
    },
  ]);
}
