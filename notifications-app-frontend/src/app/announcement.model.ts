import { Category } from './category.model';

export interface Announcement {
  id: string;
  title: string;
  author: string;
  message: string;
  categoryId: string;
  imageUrl: string;
}
