import { Injectable } from '@angular/core';
import { Category } from '../category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private categories: Category[] = [
    {
      id: '1',
      name: 'Course',
    },
    {
      id: '2',
      name: 'General',
    },
    {
      id: '3',
      name: 'Laboratory',
    },
  ];

  constructor() {}

  getCategories() {
    return this.categories;
  }

  getIdGivenName(givenName: string): string {
    let categoryId: string;
    this.categories.forEach((category) => {
      if (category.name == givenName) {
        categoryId = category.id;
      }
    });
    return categoryId;
  }

  getNameGivenId(givenId: string): string {
    let categoryName: string;
    this.categories.forEach((category) => {
      if (category.id == givenId) {
        categoryName = category.name;
      }
    });
    return categoryName;
  }
}
